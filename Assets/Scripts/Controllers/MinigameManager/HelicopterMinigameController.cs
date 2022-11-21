using DG.Tweening;
using Signals;
using UnityEngine;

namespace Controllers.MinigameManager
{
    public class HelicopterMinigameController : MonoBehaviour
    {
        #region Self Variables
        #region Serialized Variables

        [SerializeField] private GameObject minigamePlatform;
        [SerializeField] private GameObject door;

        #endregion
        #region Private Variables

        private int _stackCount;

        #endregion
        #endregion
        
        private int StackCount() { _stackCount = (int)MinigameSignals.Instance.onStackCount?.Invoke(); return _stackCount;}
        public void Close()
        {
            if (StackCount() <= 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (transform.GetChild(i).GetComponent<Renderer>().material.name != door.GetComponent<Renderer>().material.name)
                    {
                        transform.GetChild(i).transform.DOScaleZ(0, 1).SetDelay(1.5f);
                    }
                }
            }
        }
    }
}