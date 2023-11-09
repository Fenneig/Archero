using Archero.Character.Components;
using UnityEngine;

namespace Archero.Character.Player
{
    public class PlayerMovementComponent : MovementComponent
    {
        public Vector2 Direction { set; get; }
        
        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (Direction.x != 0 || Direction.y != 0)
            {
                var moveDirection = new Vector3(Direction.x, 0, Direction.y);
                NavMeshAgent.SetDestination(CachedTransform.position + moveDirection);
            }
            else
            {
                NavMeshAgent.SetDestination(CachedTransform.position);
            }
        }
    }
}