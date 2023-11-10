using UnityEngine;

namespace Archero.UI.Panels.Factory
{
    public interface IPanelFactory
    {
        public void Load();

        public void Create(PanelType panelType, Canvas at);
    }
}