using Archero.Character.Components;
using UnityEngine;

namespace Archero.Character.Enemy
{
    public class EnemyMovementComponent : MovementComponent
    {
        public void MoveTo(Vector3 position)
        {
            NavMeshAgent.SetDestination(position);
        }

        public void Stop()
        {
            NavMeshAgent.SetDestination(CachedTransform.position);
        }
    }
}