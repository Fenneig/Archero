using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Archero.Systems.Enemy
{
    public class EnemyFactory : IEnemyFactory
    {
        private const string GROUND_ENEMY_RESOURCE_PATH = "Enemies/GroundEnemy";
        private const string FLYING_ENEMY_RESOURCE_PATH = "Enemies/FlyingEnemy";
        private Object _groundEnemy;
        private Object _flyingEnemy;

        private DiContainer _diContainer;
        
        public EnemyFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Load()
        {
            _groundEnemy = Resources.Load(GROUND_ENEMY_RESOURCE_PATH);
            _flyingEnemy = Resources.Load(FLYING_ENEMY_RESOURCE_PATH);
        }
        
        public GameObject Create(EnemyType enemyType, Vector3 at)
        {
            return enemyType switch
            {
                EnemyType.Ground => _diContainer.InstantiatePrefab(_groundEnemy, at, Quaternion.identity, null),
                EnemyType.Flying => _diContainer.InstantiatePrefab(_flyingEnemy, at, Quaternion.identity, null),
                _ => null
            };
        }
    }
}