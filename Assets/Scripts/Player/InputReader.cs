using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Archero.Player
{
    [RequireComponent(typeof(MovementComponent))]
    public class InputReader : MonoBehaviour
    {
        private MovementComponent _movementComponent;

        private void Awake()
        {
            _movementComponent = GetComponent<MovementComponent>();
        }

        [UsedImplicitly]
        public void OnMovement(InputAction.CallbackContext context)
        {
            _movementComponent.Direction = context.ReadValue<Vector2>();
        }
    }
}
