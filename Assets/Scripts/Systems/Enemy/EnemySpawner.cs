using System.Collections.Generic;
using Archero.Character.Enemy;
using Archero.Character.Player;
using UnityEngine;
using Zenject;

namespace Archero.Systems.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<EnemyMarker> _enemies; 
        private IEnemyFactory _enemyFactory;
        private List<Transform> _enemiesList;
        
        [Inject]
        private void Construct(IEnemyFactory enemyFactory, PlayerUnit playerUnit)
        {
            _enemyFactory = enemyFactory;
            _enemyFactory.Load();
            _enemiesList = playerUnit.EnemiesTransform;
        }

        private void Start()
        {
            SpawnEnemies();
        }

        [ContextMenu("Spawn")]
        public void SpawnEnemies()
        {
            _enemies.ForEach(SpawnEnemy);
        }

        private void SpawnEnemy(EnemyMarker enemy)
        {
            EnemyUnit enemyUnit = _enemyFactory.Create(enemy.EnemyType, enemy.transform.position).GetComponent<EnemyUnit>();

            _enemiesList.Add(enemyUnit.CachedTransform);
            enemyUnit.HealthComponent.OnDied += () => _enemiesList.Remove(enemyUnit.CachedTransform);
        }
    }
}