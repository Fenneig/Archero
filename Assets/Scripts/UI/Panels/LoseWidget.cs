using Archero.Systems;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Archero.UI.Panels
{
    public class LoseWidget : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
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
            
            _exitButton.onClick.AddListener(Application.Quit);
        }
    }
}