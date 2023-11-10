using System.Collections.Generic;

namespace Archero.Systems.Pause
{
    public class PauseService : IPauseHandler
    {
        private readonly List<IPauseHandler> _handlers = new();

        private static PauseService _instance;

        public static PauseService I => _instance ??= new PauseService();

        public bool IsPaused { get; private set; }

        public void Register(IPauseHandler handler)
        {
            _handlers.Add(handler);
        }

        public void UnRegister(IPauseHandler handler)
        {
            _handlers.Remove(handler);
        }

        public void SetPaused(bool isPaused)
        {
            IsPaused = isPaused;
            
            foreach (var handler in _handlers)
            {
                handler.SetPaused(isPaused);
            }
        }
    }
}