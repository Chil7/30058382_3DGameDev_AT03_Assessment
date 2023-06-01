using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Animations;
using FSM;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent agent;
    private Animator animator;

    //GameOver
    private bool playerCaught = false;
    public delegate void GameEndDelegate();
    public event GameEndDelegate GameOverEvent = delegate { };

    //Targets
    [SerializeField] private GameObject playerTarget;

    //Ranges
    [SerializeField] private float detectionDistance;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float attackDistance;

    //Speed
    [SerializeField] private float patrolSpeed;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float huntingSpeed;

    //Patrol
    public Area currArea;

    //Hunting State
    [SerializeField] LayerMask whatIsGround;
    [SerializeField] float huntPointRange;

    public StateMachine StateMachine { get; private set; }

    private void Awake()
    {
        StateMachine = new StateMachine();

        if(!TryGetComponent<NavMeshAgent>(out agent))
        {
            Debug.LogError("This object needs an object agent attached to it");
        }

        if (!GetComponentInChildren<Animator>())
        {
            Debug.LogError("This object needs an animator attached to it");
        }

        if(currArea == null)
        {
            Debug.LogError("This needs an object with an Area Script reference to it");
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        StateMachine.SetState(new IdleState(this));
    }

    // Update is called once per frame
    void Update()
    {
        StateMachine.OnUpdate();
    }

    public abstract class EnemyMoveState : IState
    {
        protected Enemy instance;

        public EnemyMoveState(Enemy _instance)
        {
            instance = _instance;
        }

        public virtual void OnEnter()
        {

        }

        public virtual void OnExit()
        {

        }

        public virtual void OnUpdate()
        {

        }
    }

    public class IdleState : EnemyMoveState
    {
        public IdleState(Enemy _instance) : base(_instance)
        {
        }

        float timeSecondsIdle;

        public override void OnEnter()
        {
            Debug.Log("On Idle");
            //play idle animation
            instance.agent.speed = 0;
            timeSecondsIdle = Random.Range(3f, 10f);
            instance.StartCoroutine(StopIdle());
        }

        public override void OnUpdate()
        {
            //If player is within detection range; Chase player
            if (Vector3.Distance(instance.transform.position, instance.playerTarget.transform.position) < instance.detectionDistance)
            {
                instance.StateMachine.SetState(new ChaseState(instance));
            }

        }

        public override void OnExit()
        {
            //If player is detected within Idle countdown, it will stop the coroutine
            instance.StopAllCoroutines();
        }

        IEnumerator StopIdle()
        {
            while (timeSecondsIdle > 0)
            {
                yield return new WaitForSeconds(1f);
                timeSecondsIdle--;
            }
            instance.StateMachine.SetState(new PatrolState(instance));
        }
    }

    public class PatrolState : EnemyMoveState
    {
        public PatrolState(Enemy _instance) : base(_instance)
        {
        }

        public override void OnEnter()
        {
            Debug.Log("On Patrol");

            //play walk cycle animation
            instance.agent.speed = instance.patrolSpeed;

            SearchNewAreaToPatrol();
        }

        public override void OnUpdate()
        {
            //If player is within detection range; Chase player
            if (Vector3.Distance(instance.transform.position, instance.playerTarget.transform.position) < instance.detectionDistance)
            {
                instance.StateMachine.SetState(new ChaseState(instance));
            }
            else if (Vector3.Distance(instance.transform.position, instance.currArea.transform.position) < instance.stoppingDistance)
            {
                int randomNum = Random.Range(1, 10);
                instance.currArea.isSearched = true;
                instance.currArea = instance.currArea.Neighbour;
                if (randomNum > 3)
                {
                    instance.StateMachine.SetState(new IdleState(instance));
                }
                else
                {
                    instance.StateMachine.SetState(new HuntingState(instance));
                }
            }
        }

        public override void OnExit()
        {
            
        }

        
        //private void SearchForNewArea()
        //{
        //    bool _isAreaSet = false;
        //    Area _currentArea = currArea;

        //    areaList.Clear();
        //    areaList.Add(_currentArea);

        //    while (_isAreaSet == false && areaList.Count > -1)
        //    {
        //        if (_currentArea.isSearched == false)
        //        {
        //            _isAreaSet = true;
        //            MoveToArea(_currentArea);
        //            break;
        //        }
        //        else if (_currentArea.isSearched == true)
        //        {
        //            foreach (Area areas in _currentArea.Neighbour)
        //            {
        //                areaList.Add(areas);
        //            }
        //            areaList.Remove(_currentArea);
        //            if (areaList.Count - 1 > 0)
        //            {
        //                if(areaList[areaList.Count - 1].isSearched == true)
        //                {
        //                    _isAreaSet = true;
        //                    currArea = areaList[0];
        //                    MoveToArea(currArea);
        //                    break;
        //                }
        //                else
        //                {
        //                    _isAreaSet = true;
        //                    currArea = areaList[areaList.Count - 1];
        //                    MoveToArea(currArea);
        //                    break;
        //                }
        //            }
        //            else
        //            {
        //                break;
        //            }
        //        }
                
        //    }
        //} 

        private void SearchNewAreaToPatrol()
        {
            bool _isAreaSet = false;

            if (instance.currArea == null)
            {
                instance.currArea = GameManager.Instance.Areas[0];
            }

            while (_isAreaSet == false)
            {
                if (instance.currArea.isSearched == false)
                {
                    _isAreaSet = true;
                    MoveToArea(instance.currArea);
                    break;
                }
                else
                {
                    _isAreaSet = true;
                    instance.currArea = instance.currArea.Neighbour;
                    Debug.Log("new area is " + instance.currArea);
                    MoveToArea(instance.currArea);
                    break;
                }
            }
        }

        public void MoveToArea(Area area)
        {
            //Go to the designated area
            if (Vector3.Distance(instance.transform.position, area.transform.position) > instance.stoppingDistance)
            {
                instance.agent.SetDestination(area.transform.position);
            }
            Debug.Log(area);
        }
    }

    public class ChaseState : EnemyMoveState
    {
        public ChaseState(Enemy _instance) : base(_instance)
        {
        }

        public override void OnEnter()
        {
            Debug.Log("On Chase");
            //play run cycle animation
            instance.detectionDistance = 10;
            instance.agent.speed = instance.chaseSpeed;
        }

        public override void OnUpdate()
        {
            if (Vector3.Distance(instance.transform.position, instance.playerTarget.transform.position) < instance.attackDistance)
            {
                instance.StateMachine.SetState(new AttackState(instance));
            }
            if (Vector3.Distance(instance.transform.position, instance.playerTarget.transform.position) < instance.detectionDistance)
            {
                instance.agent.SetDestination(instance.playerTarget.transform.position);
            }
        }

        public override void OnExit()
        {
            instance.detectionDistance = 7;
        }
    }

    public class HuntingState : EnemyMoveState
    {
        public HuntingState(Enemy _instance) : base(_instance)
        {
        }

        //Timer
        float timeSecondsHunt;

        //Hunting
        Vector3 huntPoint;
        bool huntPointSet;


        public override void OnEnter()
        {
            Debug.Log("Hunting");
            //play walk hunting animation (similar to walk)
            instance.agent.speed = instance.huntingSpeed;
            timeSecondsHunt = Random.Range(8f, 10f);
            instance.StartCoroutine(StopHunt());
        }

        public override void OnUpdate()
        {
            //If player is within detection range; Chase player
            if (Vector3.Distance(instance.transform.position, instance.playerTarget.transform.position) < instance.detectionDistance)
            {
                instance.StateMachine.SetState(new ChaseState(instance));
            }
            else
            {
                Hunting();
            }
        }

        public override void OnExit()
        {
            instance.StopAllCoroutines();
        }

        private void Hunting()
        {
            if (!huntPointSet)
            {
                SearchHuntPoint();
            }
            if (huntPointSet)
            {
                instance.agent.SetDestination(huntPoint);
            }

            Vector3 distanceToHuntPoint = instance.transform.position - huntPoint;

            //huntpoint reached
            if (distanceToHuntPoint.magnitude < 1f)
            {
                huntPointSet = false;
            }
        }

        private void SearchHuntPoint()
        {
            //Calculate random point in range
            float randomZ = Random.Range(-instance.huntPointRange, instance.huntPointRange);
            float randomX = Random.Range(-instance.huntPointRange, instance.huntPointRange);

            //Set Hunt point
            huntPoint = new Vector3(instance.transform.position.x + randomX, instance.transform.position.y, instance.transform.position.z + randomZ);

            if (Physics.Raycast(huntPoint, -instance.transform.up, 2f, instance.whatIsGround))
            {
                huntPointSet = true;
            }
        }

        IEnumerator StopHunt()
        {
            while (timeSecondsHunt > 0)
            {
                yield return new WaitForSeconds(1f);
                timeSecondsHunt--;
            }
            instance.StateMachine.SetState(new PatrolState(instance));
        }
    }

    public class StunState : EnemyMoveState
    {
        public StunState(Enemy _instance) : base(_instance)
        {
        }

        float timeSecondsStun = 3.5f;

        public override void OnEnter()
        {
            instance.StopAllCoroutines();
            Debug.Log("On Stun");
            //play stunned animation
            instance.agent.speed = 0;
            instance.StartCoroutine(StopStun());
        }

        public override void OnUpdate()
        {

        }

        public override void OnExit()
        {

        }

        IEnumerator StopStun()
        {
            while (timeSecondsStun > 0)
            {
                yield return new WaitForSeconds(1f);
                timeSecondsStun--;
            }
            instance.StateMachine.SetState(new HuntingState(instance));
        }
    }

    public class AttackState : EnemyMoveState
    {
        public AttackState(Enemy _instance) : base(_instance)
        {
        }

        public override void OnEnter()
        {
            Debug.Log("On Attack");
            //play punch animation
            instance.agent.speed = 0;
            instance.playerCaught = true;
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnExit()
        {

        }
        
    }
    

    private void OnDrawGizmos()
    {
        //Detection Distance
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionDistance);

        //Attack Range
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackDistance);

        //Hunting Range
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, huntPointRange);
    }

    
}
