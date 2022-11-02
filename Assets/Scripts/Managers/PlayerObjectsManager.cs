using Controllers.PlayerObjectsManager;
using UnityEngine;

namespace Managers
{
    public class PlayerObjectsManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables
        
        #endregion

        #region Serialized Variables

        [SerializeField] private PlayerObjectsController playerObjectsController;
        [SerializeField] private Animator animator;

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

        public void PlayerAnimation()
        {
            
        }

        public void PlayersMinigameControl()
        {
            playerObjectsController.MinigameControl();
        }

        public void PlayerColorChange(GameObject door)
        {
            playerObjectsController.Comparison(door);
        }
    }
}