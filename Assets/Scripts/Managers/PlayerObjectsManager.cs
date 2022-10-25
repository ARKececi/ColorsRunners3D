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

        public void PlayerAnimation()
        {
            
        }

        public void PlayerColorChange()
        {
            playerObjectsController.ColorChange();
        }
    }
}