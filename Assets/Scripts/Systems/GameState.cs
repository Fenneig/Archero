using System.Collections.Generic;
using Archero.Character.Player;
using Archero.Systems.Pause;
using Archero.UI.Panels.Factory;
using UnityEngine;
using Zenject;

namespace Archero.Systems
{
    public class GameState : MonoBehaviour
    {
        [SerializeField] private Canvas _mainCanvas;

        private IPanelFactory _panelFactory;
        private List<Transform> _enemiesAlive;
        private ExitRoom _exitRoom;

        [Inject]
        private void Construct(PlayerUnit playerUnit, IPanelFactory panelFactory, ExitRoom exitRoom)
        {
            playerUnit.HealthComponent.OnDied += GameLose;
            _enemiesAlive = playerUnit.EnemiesTransform;
            _panelFactory = panelFactory;
            _exitRoom = exitRoom;
        }
        
        private void GameLose()
        {
            PauseService.I.SetPaused(true);
            _panelFactory.Create(PanelType.Lose, _mainCanvas);
        }

        public void GameWin()
        {
            PauseService.I.SetPaused(true);
            _panelFactory.Create(PanelType.Win, _mainCanvas);
        }

        public void CheckGameState()
        {
            if (_enemiesAlive.Count == 0)
            {
                _exitRoom.ShowExit();
            }
        }
    }
}