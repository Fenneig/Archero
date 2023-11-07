using Archero.Definitions;
using UnityEngine;

namespace Archero.Character.Player
{
    [RequireComponent(typeof(PlayerMovementComponent))]
    public class PlayerUnit : Unit
    {
        [SerializeField] private PlayerDefinition _playerDefinition;
        public PlayerMovementComponent MovementComponent { get; private set; }

        protected override void Awake()
        {
            base.Awake();
            MovementComponent = GetComponent<PlayerMovementComponent>();
            MovementComponent.Setup(_playerDefinition.MoveSpeed);
        }
    }
}