using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class PlayerSignals : MonoSingleton<PlayerSignals>
    {
        public UnityAction<string> onPlayerAnimation = delegate { };
        public UnityAction onStackStriking = delegate { };
        public UnityAction<GameObject> onPlatform = delegate { };
        public UnityAction onTarretMinigame = delegate { };
    }
}