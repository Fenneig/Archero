using UnityEngine;
using UnityEngine.AI;

namespace Archero.Player
{
    public class MovementComponent : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent _nmAgent;
        
        public Vector2 Direction { set; get; }

        //Modifier that makes navmesh feels "smooth"
        private const float ACCELERATION_MODIFIER = 2f;


        public void Setup(float speed)
        {
            _nmAgent.speed = speed;
            _nmAgent.acceleration = speed * ACCELERATION_MODIFIER;
        }

        private void Update()
        {
            Move();
        }

        private void Move()
        {
            if (Direction.x != 0 || Direction.y != 0)
            {
                var moveDirection = new Vector3(Direction.x, 0, Direction.y);
                _nmAgent.SetDestination(transform.position + moveDirection);
            }
            else
            {
                _nmAgent.SetDestination(transform.position);
            }
        }
    }
}