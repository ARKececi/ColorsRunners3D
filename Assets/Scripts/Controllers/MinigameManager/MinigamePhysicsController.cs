using System;
using Signals;
using UnityEngine;

namespace Controllers.MinigameManager
{
    public class MinigamePhysicsController : MonoBehaviour
    {
        #region Self Variables
        #region Serialized Variables

        [SerializeField] private MinigameController minigameController;

        #endregion
        #endregion
        private void OnTriggerEnter(Collider other)
        {
            if (transform.CompareTag("MinigameHelicopter"))
            {
                if (other.CompareTag("PlayerObj"))
                {
                    minigameController.Close();
                }
            }
        }
    }
}