using Archero.Systems.Pause;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Archero.UI.Panels
{
    public class WinWidget : MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _exitButton;
        private void Awake()
        {
            _restartButton.onClick.AddListener(() 
                =>
            {
                PauseService.I.SetPaused(false);
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            });
            
            _exitButton.onClick.AddListener(Application.Quit);
        }
    }
}