using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class StackSignals : MonoSingleton<StackSignals>
    {
        public UnityAction onPlatformClose = delegate { };
        public UnityAction<GameObject> onMinigameColor = delegate { };
    }
}