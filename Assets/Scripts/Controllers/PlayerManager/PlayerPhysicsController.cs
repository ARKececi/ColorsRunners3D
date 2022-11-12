using System;
using DG.Tweening;
using Signals;
using UnityEngine;

namespace Controllers.PlayerManager
{
    public class PlayerPhysicsController : MonoBehaviour
    {
        #region Self Varibles

        #region Serialized Variables

        [SerializeField] private PlayerMovementController playerMovementController;

        #endregion

        #endregion
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("MinigameTarret"))
            {
                playerMovementController.SlowMove();
            }
        }
    }
}