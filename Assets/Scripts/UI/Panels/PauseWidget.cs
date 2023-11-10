using Archero.Systems.Pause;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Archero.UI.Panels
{
    public class PauseWidget : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _resumeButton;
        [SerializeField] private Button _exitButton;
        
        private void Awake()
        {
            _restartButton.onClick.AddListener(() 
                =>
            {
                PauseService.I.SetPaused(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            });
            
            _resumeButton.onClick.AddListener(() =>
            {
                PauseService.I.SetPaused(false);
                Destroy(gameObject);
            });
            
            _exitButton.onClick.AddListener(Application.Quit);
        }
    }
}