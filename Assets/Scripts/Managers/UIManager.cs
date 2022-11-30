using System;
using Controllers.UIManager;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private UIPanelController uıPanelController;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            StackSignals.Instance.onUIReset += OnReset;
        }

        private void UnsubscribeEvents()
        {
            StackSignals.Instance.onUIReset -= OnReset;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        
        #endregion

        public void Play()
        {
            uıPanelController.OnClosePanel(UIPanel.PlayButton);
            CoreGameSignals.Instance.onPlay?.Invoke();
        }

        public void Reset()
        {
            CoreGameSignals.Instance.onReset?.Invoke();
            uıPanelController.OnClosePanel(UIPanel.Reset);
            uıPanelController.OnOpenPanel(UIPanel.PlayButton);
        }

        public void OnReset()
        {
            uıPanelController.OnOpenPanel(UIPanel.Reset);
        }
    }
}