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

        float timeSeconds;

        public override void OnEnter()
        {
            Debug.Log("On Idle");
            //play idle animation
            instance.agent.speed = 0;
            timeSeconds = Random.Range(3, 10);
            Debug.Log(timeSeconds);
        }

        public override void OnUpdate()
        {
            //Put timer
            //If player is within detection range; Chase player
            if (Vector3.Distance(instance.transform.position, instance.playerTarget.transform.position) < instance.detectionDistance)
            {
                instance.StateMachine.SetState(new ChaseState(instance));
            }
            else if (Vector3.Distance(instance.transform.position, instance.navTarget.transform.position) > instance.stoppingDistance)
            {
                //Switch to Patrol State
                instance.StateMachine.SetState(new PatrolState(instance));
            }
        }

        public override void OnExit()
        {

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

        }

        public override void OnExit()
        {

        }
    }

    public class StunState : EnemyMoveState
    {
        public StunState(Enemy _instance) : base(_instance)
        {
        }

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
}
