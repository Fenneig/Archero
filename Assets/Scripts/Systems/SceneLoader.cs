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

        public void ReloadScene()
        {
            PauseService.I.SetPaused(false);
            SceneManager.LoadScene(_mainSceneName);
            _additionalScenesName.ForEach(sceneName => SceneManager.LoadScene(sceneName, LoadSceneMode.Additive));
        }
    }
}