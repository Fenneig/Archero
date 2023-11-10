using System.Collections.Generic;
using Archero.Systems.Pause;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Archero.Systems
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private string _mainSceneName;
        [SerializeField] private List<string> _additionalScenesName;

        private void Awake()
        {
            PauseService.I.SetPaused(false);
            _additionalScenesName.ForEach(sceneName => SceneManager.LoadScene(sceneName, LoadSceneMode.Additive));
        }

        public void LoadScenes()
        {
            SceneManager.LoadScene(_mainSceneName);
        }
    }
}