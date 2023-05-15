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

        public override void OnEnter()
        {

        }

        public override void OnUpdate()
        {

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

        }

        public override void OnUpdate()
        {

        }

        public override void OnExit()
        {

        }
    }
}
