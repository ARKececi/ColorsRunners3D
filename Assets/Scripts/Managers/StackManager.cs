using System;
using Controllers.StackManager;
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

        

        #endregion

        #endregion
        
        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {

        }

        private void UnsubscribeEvents()
        {

        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void FixedUpdate()
        {
            stackController.PositionUpdate();
            stackController.MoveStack();
        }

        private void OnStackAdd(GameObject obj)
        {
            
        }
    }
}