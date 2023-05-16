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

    //Targets
    [SerializeField] private GameObject navTarget;
    [SerializeField] private GameObject playerTarget;

    //Ranges
    [SerializeField] private float detectionDistance;
    [SerializeField] private float stoppingDistance;
    [SerializeField] private float attackDistance;

    //Speed
    [SerializeField] private float patrolSpeed;
    [SerializeField] private float chaseSpeed;
    [SerializeField] private float huntingSpeed;
    

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
            Debug.Log(timeSecondsIdle);
            instance.StartCoroutine(OnIdle());
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

        IEnumerator OnIdle()
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
        }

        public override void OnUpdate()
        {
            
        }

        public override void OnExit()
        {
            
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
            instance.agent.speed = instance.chaseSpeed;
        }

        public override void OnUpdate()
        {
            if (Vector3.Distance(instance.transform.position, instance.playerTarget.transform.position) < instance.detectionDistance)
            {
                instance.agent.SetDestination(instance.playerTarget.transform.position);
            }
            else
            {
                instance.StateMachine.SetState(new HuntingState(instance));
            }
        }

        public override void OnExit()
        {

        }
    }

    public class HuntingState : EnemyMoveState
    {
        public HuntingState(Enemy _instance) : base(_instance)
        {
        }

        float timeSecondsHunt;

        public override void OnEnter()
        {
            Debug.Log("Hunting");
            //play walk hunting animation (similar to walk)
            instance.agent.speed = instance.huntingSpeed;
            timeSecondsHunt = Random.Range(5f, 10f);
            Debug.Log(timeSecondsHunt);
            instance.StartCoroutine(OnHunt());
        }

        public override void OnUpdate()
        {
    
        }

        public override void OnExit()
        {
 
        }

        IEnumerator OnHunt()
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

        float timeSecondsStun;

        public override void OnEnter()
        {
            Debug.Log("On Stun");
            //play stunned animation
            instance.agent.speed = 0;
        }

        public override void OnUpdate()
        {

        }

        public override void OnExit()
        {

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
    }
}
