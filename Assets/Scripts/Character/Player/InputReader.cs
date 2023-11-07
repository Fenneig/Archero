using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Archero.Character.Player
{
    [RequireComponent(typeof(PlayerUnit))]
    public class InputReader : MonoBehaviour
    {
        private PlayerUnit _playerUnit;

        private void Awake()
        {
            _playerUnit = GetComponent<PlayerUnit>();
        }

        [UsedImplicitly]
        public void OnMovement(InputAction.CallbackContext context)
        {
            _playerUnit.MovementComponent.Direction = context.ReadValue<Vector2>();
        }
    }
}
