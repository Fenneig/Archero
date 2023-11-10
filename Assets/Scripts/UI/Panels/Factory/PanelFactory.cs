using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Archero.UI.Panels.Factory
{
    public class PanelFactory : IPanelFactory
    {
        private const string WIN_PANEL_RESOURCE_PATH = "Panels/WinPanel";
        private const string LOSE_PANEL_RESOURCE_PATH = "Panels/LosePanel";
        private const string PAUSE_PANEL_RESOURCE_PATH = "Panels/PausePanel";
        private Object _winPanel;
        private Object _losePanel;
        private Object _pausePanel;

        private DiContainer _diContainer;

        public PanelFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public void Load()
        {
            if (_winPanel == null) _winPanel = Resources.Load(WIN_PANEL_RESOURCE_PATH);
            if (_losePanel == null) _losePanel = Resources.Load(LOSE_PANEL_RESOURCE_PATH);
            if (_pausePanel == null) _pausePanel = Resources.Load(PAUSE_PANEL_RESOURCE_PATH);
        }

        public void Create(PanelType panelType, Canvas at)
        {
            switch (panelType)
            {
                case PanelType.Win:
                    _diContainer.InstantiatePrefab(_winPanel, at.transform);
                    break;
                case PanelType.Lose:
                    _diContainer.InstantiatePrefab(_losePanel, at.transform);
                    break;
                case PanelType.Pause:
                    _diContainer.InstantiatePrefab(_pausePanel, at.transform);
                    break;
            }
        }
    }
}