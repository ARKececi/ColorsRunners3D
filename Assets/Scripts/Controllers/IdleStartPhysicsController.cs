using System;
using Enums;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class IdleStartPhysicsController : MonoBehaviour
    {
        #region Self Variables
        #region Serialized Variables

        [SerializeField] private GameObject ıdleObj;

        #endregion
        #endregion
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                //CoreGameSignals.Instance.onStation?.Invoke(true);
                ıdleObj.transform.position = other.transform.position;
                ıdleObj.SetActive(true);
                PlayerSignals.Instance.onPlayCamera?.Invoke(CameraState.Casual);
                MinigameSignals.Instance.onSetCamera?.Invoke(ıdleObj);
                CoreGameSignals.Instance.onGameChange?.Invoke();
                
                //transform.GetComponent<BoxCollider>().isTrigger = false;
            }
        }
    }
}