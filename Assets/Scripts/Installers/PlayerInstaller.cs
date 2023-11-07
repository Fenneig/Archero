using Archero.Player;
using UnityEngine;
using Zenject;

namespace Archero.Installers
{
    public class PlayerInstaller : MonoInstaller
    {
        [SerializeField] private PlayerUnit _playerUnitPrefab;
        [SerializeField] private Transform _playerSpawnPosition;
        
        public override void InstallBindings()
        {
            var player = Container.InstantiatePrefabForComponent<PlayerUnit>(
                _playerUnitPrefab, _playerSpawnPosition.position, Quaternion.identity, null);

            Container.Bind<PlayerUnit>().
                FromInstance(player).
                AsSingle().
                NonLazy();
            Container.QueueForInject(player);
        }
    }
}
