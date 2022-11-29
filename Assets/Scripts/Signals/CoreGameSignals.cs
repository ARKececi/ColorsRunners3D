using Extentions;
using Keys;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction onReset = delegate { };
        public UnityAction onPlay  = delegate { };
        public UnityAction onFinish = delegate { };
        public UnityAction OnGameChange = delegate { };
        public UnityAction<bool> onStation = delegate { };
        public UnityAction<string> minigameState = delegate { };
        
    }
}