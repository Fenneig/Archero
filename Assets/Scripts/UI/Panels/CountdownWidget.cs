using System.Collections;
using Archero.Systems.Enemy;
using Archero.Systems.Pause;
using TMPro;
using UnityEngine;
using Zenject;

namespace Archero.UI.Panels
{
    public class CountdownWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _text;

        private EnemySpawner _enemySpawner;

        [Inject]
        private void Construct(EnemySpawner enemySpawner)
        {
            _enemySpawner = enemySpawner;
        }
        private void Start()
        {
            StartCoroutine(BeginCountdown());
            PauseService.I.SetPaused(true);
        }
        
        // ¯\_(ツ)_/¯
        private IEnumerator BeginCountdown()
        {
            yield return new WaitForSeconds(1f);
            _text.text = "2";
            yield return new WaitForSeconds(1f);
            _text.text = "1";
            yield return new WaitForSeconds(1f);
            _text.text = "0";
            PauseService.I.SetPaused(false);
            _enemySpawner.SpawnEnemies();
            Destroy(gameObject);
        }
    }
}