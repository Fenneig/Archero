using Archero.Utils;
using UnityEngine;

namespace Archero.Definitions
{
    [CreateAssetMenu(menuName = "Definitions/Enemy")]
    public class EnemyDefinition : UnitDefinition
    {
        [SerializeField] private Timer _idleTimer;
        public Timer IdleTimer => _idleTimer;
    }
}