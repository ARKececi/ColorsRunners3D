using System;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class IdleStartPhysicsController : MonoBehaviour
    {
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                CoreGameSignals.Instance.onStation?.Invoke(true);
                CoreGameSignals.Instance.OnGameChange?.Invoke();
                transform.GetComponent<BoxCollider>().isTrigger = false;
            }
        }
    }
}