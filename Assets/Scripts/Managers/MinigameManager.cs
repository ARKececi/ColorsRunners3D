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

        [SerializeField] private MinigameController _minigameController;

        #endregion

        #endregion
        
        #region Event Subscription
        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            StackSignals.Instance.onPlatformClose += OnPlatformClose;
            PlayerSignals.Instance.onPlatform += OnPlatform;
            PlayerSignals.Instance.onTarretMinigame += OnTarretMinigame;
        }

        private void UnsubscribeEvents()
        {
            StackSignals.Instance.onPlatformClose -= OnPlatformClose;
            PlayerSignals.Instance.onPlatform -= OnPlatform;
            PlayerSignals.Instance.onTarretMinigame += OnTarretMinigame;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion
        
        private void OnPlatformClose()
        {
            _minigameController.Close();
        }

        private void OnPlatform(GameObject obj)
        {
            _minigameController.Platform(obj);
        }

        private void OnTarretMinigame()
        {
            StartCoroutine(_minigameController.TargetMinigame());
        }
    }
}