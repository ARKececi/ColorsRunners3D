using System;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class MinigameSignals : MonoSingleton<MinigameSignals>
    {
        public UnityAction onPlayExecution = delegate { };
        public UnityAction onSlowlyStackAdd = delegate { };
        public Func<int> onStackCount = delegate { return new int();};
    }
}