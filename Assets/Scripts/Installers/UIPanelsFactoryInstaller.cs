using Archero.UI.Panels.Factory;
using Zenject;

namespace Archero.Installers
{
    public class UIPanelsFactoryInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container
                .Bind<IPanelFactory>()
                .To<PanelFactory>()
                .AsSingle();
        }
    }
}