using System;
using System.Collections.Generic;
using Archero.Character.Enemy;
using Archero.Character.Player;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace Archero.Systems.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<EnemyMarker> _enemies; 
        private IEnemyFactory _enemyFactory;
        private List<Transform> _enemiesList;

        private Action _checkGameState;
        
        [Inject]
        private void Construct(IEnemyFactory enemyFactory, PlayerUnit playerUnit, GameState gameState)
        {
            _enemyFactory = enemyFactory;
            _enemyFactory.Load();
            _enemiesList = playerUnit.EnemiesTransform;
            _checkGameState = gameState.CheckGameState;
        }

        public void SpawnEnemies()
        {
            _enemies.ForEach(SpawnEnemy);
        }

        private void SpawnEnemy(EnemyMarker enemy)
        {
            //TODO: сделать нормальный рандомайзер создания врагов. 
            if (Random.Range(0,2) == 0) return;
            
            EnemyUnit enemyUnit = _enemyFactory.Create(enemy.EnemyType, enemy.transform.position).GetComponent<EnemyUnit>();
            _enemiesList.Add(enemyUnit.CachedTransform);
            enemyUnit.HealthComponent.OnDied += () =>
            {
                _enemiesList.Remove(enemyUnit.CachedTransform);
                _checkGameState?.Invoke();
            };
        }
    }
}