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
                    DOVirtual.DelayedCall(.5f,()=>CoreGameSignals.Instance.onFinish?.Invoke());
                    DOVirtual.DelayedCall(.51f,()=>StackSignals.Instance.minigameState?.Invoke("helicopterMinigame"));
                    
                }
            }
        }
    }
}