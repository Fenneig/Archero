using UnityEngine;

namespace Archero.Systems.Enemy
{
    public interface IEnemyFactory
    {
        void Load();
        GameObject Create(EnemyType enemyType, Vector3 at);
    }
}