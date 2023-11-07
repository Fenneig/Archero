using Archero.Definitions;
using UnityEngine;

namespace Archero.Player
{
    [RequireComponent(typeof(MovementComponent))]
    public class PlayerUnit : MonoBehaviour
    {
        [SerializeField] private PlayerDefinition _playerDefinition;
        private MovementComponent _movementComponent;
        
        private void Awake()
        {
            _movementComponent = GetComponent<MovementComponent>();
            _movementComponent.Setup(_playerDefinition.Speed);
        }
    }
}