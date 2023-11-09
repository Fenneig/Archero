using Archero.Character.Enemy.States;
using Archero.Character.Player;
using Archero.Definitions;
using Archero.Utils;
using DG.Tweening;
using UnityEngine;
using Zenject;

namespace Archero.Character.Enemy
{
    [RequireComponent(typeof(EnemyMovementComponent))]
    public class EnemyUnit : Unit
    {
        [Header("Behaviour states"), Space]
        [SerializeField] private AttackState _attackState;
        [SerializeField] private ChasePlayerState _chasePlayerState;
        [SerializeField] private IdleState _idleState;
        [Header("Definition"), Space]
        [SerializeField] private EnemyDefinition _enemyDefinition;
        [SerializeField] private float _attackPrepareRange;
        [SerializeField] private float _attackRange;
        
        private BehaviourState _currentState;

        public Transform TargetTransform { get; private set; }
        public EnemyMovementComponent MovementComponent { get; private set; }
        public Timer IdleTimer => _enemyDefinition.IdleTimer;
        private float DistanceToTarget => TargetTransform == null ? 0 : (CachedTransform.position - TargetTransform.position).magnitude;

        [Inject]
        private void Construct(PlayerUnit playerUnit)
        {
            TargetTransform = playerUnit.CachedTransform;
            playerUnit.HealthComponent.OnDied += () => TargetTransform = null;
        }

        protected override void Awake()
        {
            base.Awake();
            SetupComponents();
            SetState(_idleState);
        }

        protected override void SetupComponents()
        {
            base.SetupComponents();
            AttackCooldown = new Timer {Value = 1f / _enemyDefinition.AttackSpeed};
            MovementComponent = GetComponent<EnemyMovementComponent>();
            
            MovementComponent.Setup(_enemyDefinition.MoveSpeed, CachedTransform);
            AttackComponent.Setup(CachedTransform, AttackCooldown, _enemyDefinition.AttackDamage);
            AttackComponent.SetTarget(TargetTransform);
            HealthComponent.Setup(_enemyDefinition.Hp);
        }

        private void Update()
        {
            if (!_currentState.IsFinished)
            {
                _currentState.OnUpdate();
            }
            else
            {
                if (AttackCooldown.IsReady && _attackRange >= DistanceToTarget && AttackComponent.IsTargetInView())
                {
                    SetState(_attackState);
                }
                else if (_attackRange < DistanceToTarget || !AttackComponent.IsTargetInView())
                {
                    SetState(_chasePlayerState);
                }
            }
        }

        private void SetState(BehaviourState state)
        {
            _currentState = Instantiate(state);
            _currentState.StateOwner = this;
            _currentState.Init();
        }
        
        public bool IsReadyForAttack() => 
            DistanceToTarget <= _attackPrepareRange && AttackComponent.IsTargetInView();

        public void Attack()
        {
            CachedTransform.DOLookAt(TargetTransform.position, .1f).OnComplete(() =>
            {
                AttackComponent.Attack();
                _currentState.EarlyComplete();
            });
        }
    }
}