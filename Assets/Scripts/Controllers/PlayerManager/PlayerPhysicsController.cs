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
        [SerializeField] private Managers.PlayerManager playerManager;

        #endregion

        #endregion
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("MinigameTarret"))
            {
                playerMovementController.SlowMove();
                PlayerSignals.Instance.onTarretMinigame?.Invoke();
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("TarretPlatform"))
            {
                PlayerSignals.Instance.onPlatform?.Invoke(other.gameObject);
            }
        }
    }
}