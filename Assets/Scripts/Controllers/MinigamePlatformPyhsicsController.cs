using System;
using DG.Tweening;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class MinigamePlatformPyhsicsController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (transform.CompareTag("MinigameHelicopter"))
            {
                if (other.CompareTag("Player"))
                {
                    StackSignals.Instance.minigameState?.Invoke("HelicopterMinigame");
                    DOVirtual.DelayedCall(4, () => CoreGameSignals.Instance.onFinish?.Invoke());
                }
            }
        }
    }
}