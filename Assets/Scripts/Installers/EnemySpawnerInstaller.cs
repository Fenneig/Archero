using Archero.Systems.Enemy;
using UnityEngine;
using Zenject;

namespace Archero.Installers
{
    public class EnemySpawnerInstaller : MonoInstaller
    {
        [SerializeField] private EnemySpawner _enemySpawner;
        public override void InstallBindings()
        {
            Container
                .Bind<EnemySpawner>()
                .FromInstance(_enemySpawner)
                .AsSingle();
        }
    }
}