using Controllers.MinigameManager;
using Signals;
using UnityEngine;
using Color = Enums.Color;

namespace Managers
{
    public class MinigameManager : MonoBehaviour
    {
        #region Self Variables
        #region Serialized Variables

        [SerializeField] private TarretMinigameController _minigameController;
        [SerializeField] private HelicopterMinigameController helicopterMinigameController;

        #endregion
        #endregion
        
        #region Event Subscription
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            PlayerSignals.Instance.onPlatformClose += OnPlatformClose;
            PlayerSignals.Instance.onPlatform += OnPlatform;
            PlayerSignals.Instance.onTarretMinigame += OnTarretMinigame;
        }

        private void UnsubscribeEvents()
        {
            PlayerSignals.Instance.onPlatformClose -= OnPlatformClose;
            PlayerSignals.Instance.onPlatform -= OnPlatform;
            PlayerSignals.Instance.onTarretMinigame -= OnTarretMinigame;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion
        
        private void OnPlatformClose()
        {
            helicopterMinigameController.Close();
        }

        private void OnPlatform(GameObject obj)
        {
            _minigameController.Platform(obj);
        }

        private void OnTarretMinigame()
        {
            StartCoroutine(_minigameController.TargetLook());
        }
    }
}