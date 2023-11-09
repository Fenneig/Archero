using UnityEngine;

namespace Archero.Utils
{
    [RequireComponent(typeof(Canvas))]
    public class LookAtCamera : MonoBehaviour
    {
        private Canvas _canvas;
        private Camera _camera;

        private void Awake()
        {
            _camera = Camera.main;
            _canvas = GetComponent<Canvas>();
        }

        private void Update()
        {
            _canvas.transform.LookAt(_camera.transform);
        }
    }
}