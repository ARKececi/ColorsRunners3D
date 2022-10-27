using System;
using Controllers.StackManager;
using DG.Tweening;
using Signals;
using UnityEngine;

namespace Managers
{
    public class StackManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private StackController stackController;

        #endregion

        #region Private Variables

        private bool _helicopterMinigame;

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            StackSignals.Instance.minigameState += MinigameState;
        }

        private void UnsubscribeEvents()
        {
            StackSignals.Instance.minigameState -= MinigameState;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void MinigameState(string state)
        {
            if (state == "HelicopterMinigame")
            {
                //_helicopterMinigame = true;
                StartCoroutine(stackController.HelicopterPlatformStack());
            }
        }

        private void FixedUpdate()
        {
            stackController.PositionUpdate();
            stackController.MoveStack();
        }
    }
}