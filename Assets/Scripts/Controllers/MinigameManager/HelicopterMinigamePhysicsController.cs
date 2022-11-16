using System;
using Signals;
using UnityEngine;

namespace Controllers.MinigameManager
{
    public class HelicopterMinigamePhysicsController : MonoBehaviour
    {
        #region Self Variables
        #region Serialized Variables
        
        [SerializeField] private HelicopterMinigameController helicopterMinigameController;

        #endregion
        #endregion
        private void OnTriggerEnter(Collider other)
        {
            if (transform.CompareTag("MinigameHelicopter"))
            {
                if (other.CompareTag("PlayerObj"))
                {
                    helicopterMinigameController.Close();
                }
            }
        }
    }
}