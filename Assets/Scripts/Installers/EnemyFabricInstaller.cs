using Archero.Systems.Enemy;
using Zenject;

namespace Archero.Installers
{
    public class EnemyFabricInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IEnemyFactory>()
                .To<EnemyFactory>()
                .AsSingle();
        }
    }
}