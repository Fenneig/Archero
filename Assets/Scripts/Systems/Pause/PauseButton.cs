using System;
using Archero.UI.Panels.Factory;
using UnityEngine;
using Zenject;

namespace Archero.Systems.Pause
{
    public class PauseButton : MonoBehaviour
    {
        [SerializeField] private Canvas _mainCanvas;
        private IPanelFactory _panelFactory;
        
        [Inject]
        private void Construct(IPanelFactory panelFactory)
        {
            _panelFactory = panelFactory;
            _panelFactory.Load();
        }

        public void SetPause()
        {
            _panelFactory.Create(PanelType.Pause, _mainCanvas);
            PauseService.I.SetPaused(true);
        }
    }
}