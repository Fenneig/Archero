using UnityEngine;

namespace Archero.Systems.Pause
{
    public class PauseButton : MonoBehaviour
    {
        public void SetPause()
        {
            PauseService.I.SetPaused(!PauseService.I.IsPaused);
        }
    }
}