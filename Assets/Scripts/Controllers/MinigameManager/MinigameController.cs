using System.Collections;
using Cinemachine;
using DG.Tweening;
using Signals;
using UnityEngine;

namespace Controllers.MinigameManager
{
    public class MinigameController : MonoBehaviour
    {
        #region Self Variables
        #region Serialized Variables

        [SerializeField] private GameObject minigamePlatform;
        [SerializeField] private GameObject door;
        [SerializeField] private CinemachineVirtualCamera rightTarret;
        [SerializeField] private CinemachineVirtualCamera leftTarret;

        #endregion
        #region Private variables

        private int _stackCount;
        private GameObject _platform;
        
        #endregion
        #endregion

        private int StackCount() { _stackCount = (int)MinigameSignals.Instance.onStackCount?.Invoke(); return _stackCount;}
        public void Close()
        {
            if (StackCount() <= 0)
            {
                for (int i = 0; i < 2; i++)
                {
                    if (minigamePlatform.transform.GetChild(i).GetComponent<Renderer>().material.name != door.GetComponent<Renderer>().material.name)
                    {
                        transform.GetChild(i).transform.DOScaleZ(0, 1).SetDelay(1.5f);
                        DOVirtual.DelayedCall(4, () => CoreGameSignals.Instance.onStation?.Invoke(false));
                    }
                }
            }
        }

        public void Platform(GameObject platform)
        {
            _platform = platform;
        }

        public IEnumerator TargetMinigame()
        {
            while (true)
            {
                var obj = MinigameSignals.Instance.onTarretSetObj?.Invoke(); // aynı anda atama yapıldığı için null referans veriyor.
                if (_platform.GetComponent<Renderer>().material.color != obj.transform.GetChild(0).GetComponent<Renderer>().material.color)
                {
                    rightTarret.LookAt = obj.transform;
                    leftTarret.LookAt = obj.transform;
                }
                yield return new WaitForSeconds(.15f);
            }
        }
    }
}