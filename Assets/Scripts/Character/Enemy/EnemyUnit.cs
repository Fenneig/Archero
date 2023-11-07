using Archero.Character.Enemy.States;
using Archero.Character.Player;
using Archero.Definitions;
using Archero.Utils;
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
        [SerializeField] private Timer _attackCooldown;
        [SerializeField] private float _attackPrepareRange;
        [SerializeField] private float _attackRange;

        [Inject] private PlayerUnit _playerUnit;
        private BehaviourState _currentState;

        private float DistanceToTarget => (CachedTransform.position - TargetTransform.position).magnitude;
        public Transform TargetTransform => _playerUnit.CachedTransform;
        public Timer AttackCooldown => _attackCooldown;
        public EnemyMovementComponent MovementComponent { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            MovementComponent = GetComponent<EnemyMovementComponent>();
            MovementComponent.Setup(_enemyDefinition.MoveSpeed);
            _attackCooldown.Value = 1f / _enemyDefinition.AttackSpeed;
            SetState(_idleState);
        }

        private void Update()
        {
            if (!_currentState.IsFinished)
            {
                _currentState.OnUpdate();
            }
            else
            {
                if (_attackCooldown.IsReady && _attackRange >= DistanceToTarget && TargetInView())
                {
                    SetState(_attackState);
                }
                else if (_attackRange < DistanceToTarget)
                {
                    SetState(_chasePlayerState);
                }
                else if (!_currentState.name.Contains(_idleState.name))
                {
                    SetState(_idleState);
                }
            }
        }

        private bool TargetInView()
        {
            return false;
        }

        private void SetState(BehaviourState state)
        {
            _currentState = Instantiate(state);
            _currentState.StateOwner = this;
        }


        public bool IsReadyForAttack() => 
            DistanceToTarget <= _attackPrepareRange;

        public void Attack()
        {
            _attackCooldown.Reset();
        }
    }
}