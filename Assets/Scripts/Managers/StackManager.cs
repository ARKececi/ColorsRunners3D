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
            PlayerObjectsSignals.Instance.minigameState += MinigameState;
            PlayerObjectsSignals.Instance.onListChange += OnListChange;
            PlayerObjectsSignals.Instance.onSlowlyStack += OnSlowlyStack;
            PlayerObjectsSignals.Instance.onMinigamePoolAdd += OnMinigamePoolAdd;
            MinigameSignals.Instance.onSlowlyStackAdd += OnSlowlyStackAdd;
            MinigameSignals.Instance.onStackCount += OnStackCount;
            PlayerSignals.Instance.onStackStriking += OnStackStriking;
            MinigameSignals.Instance.onTarretSetObj += OnTarretSetlist;
        }
        private void UnsubscribeEvents()
        {
            PlayerObjectsSignals.Instance.minigameState -= MinigameState;
            PlayerObjectsSignals.Instance.onListChange -= OnListChange;
            PlayerObjectsSignals.Instance.onSlowlyStack -= OnSlowlyStack;
            PlayerObjectsSignals.Instance.onMinigamePoolAdd -= OnMinigamePoolAdd;
            MinigameSignals.Instance.onSlowlyStackAdd -= OnSlowlyStackAdd;
            MinigameSignals.Instance.onStackCount -= OnStackCount;
            PlayerSignals.Instance.onStackStriking += OnStackStriking;
            MinigameSignals.Instance.onTarretSetObj += OnTarretSetlist;
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
                stackController.HelicopterPlatformStack();
            }
        }
        private void OnListChange(GameObject obj, string name)
        {
            stackController.ListChange(obj, name);
        }
        private void FixedUpdate()
        {
            stackController.PositionUpdate();
            stackController.MoveStack();
        }
        private void OnSlowlyStack(GameObject gameObject)
        {
            stackController.MinigameStackAdd(gameObject);
        }
        private void OnSlowlyStackAdd()
        {
            StartCoroutine(stackController.SlowlyStackAdd());
        }
        private void OnMinigamePoolAdd(GameObject minigameObj)
        {
            stackController.MinigamePoolAdd(minigameObj);
        }

        private int OnStackCount()
        {
           return stackController.StackCount();
        }

        private void OnStackStriking()
        {
            stackController.StackStriking();
        }

        private GameObject OnTarretSetlist()
        {
            return stackController.TarretSetObj();
        }
    }
}