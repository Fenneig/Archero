using Archero.Systems;
using Archero.Systems.Pause;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Archero.UI.Panels
{
    public class PauseWidget : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _exitButton;
        
        private SceneLoader _sceneLoader;
        
        [Inject]
        private void Construct(SceneLoader sceneLoader)
        {
            _sceneLoader = sceneLoader;
        }

        private void Awake()
        {
            _restartButton.onClick.AddListener(() => _sceneLoader.ReloadScene());
            
            _resumeButton.onClick.AddListener(() =>
            {
                PauseService.I.SetPaused(false);
                Destroy(gameObject);
            });
            
            _exitButton.onClick.AddListener(Application.Quit);
        }
    }
}