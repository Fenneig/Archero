using UnityEngine;

namespace Archero.Systems.Enemy
{
    public class EnemyMarker : MonoBehaviour
    {
        [SerializeField] private EnemyType _enemyType;
        public EnemyType EnemyType => _enemyType;
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position, 1f);
        }
    }
}