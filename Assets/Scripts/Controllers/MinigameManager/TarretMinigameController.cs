using System.Collections;
using Cinemachine;
using DG.Tweening;
using Signals;
using UnityEngine;
using UnityEngine.Events;

namespace Controllers.MinigameManager
{
    public class TarretMinigameController : MonoBehaviour
    {
        #region Self Variables
        #region Serialized Variables
        
        [SerializeField] private GameObject door;
        [SerializeField] private GameObject rightTarret;
        [SerializeField] private GameObject leftTarret;
        [SerializeField] private GameObject bullet;
        [SerializeField] private GameObject rightBarrel;
        [SerializeField] private GameObject leftBarrel;

        #endregion
        #region Private variables

        private int _stackCount;
        private GameObject _platform;
        private bool _limit;
        private int _index;
        
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
                        DOVirtual.DelayedCall(4, () => CoreGameSignals.Instance.onStation?.Invoke(false));
                    }
                }
            }
        }

        public void Platform(GameObject platform)
        {
            _platform = platform;
        }

        public void TargetStartLook()
        {
            _index++;
            switch (_index)
            {
                case 1:
                    _limit = true;
                    break;
                case 2:
                    _limit = false;
                    break;
            }
            StartCoroutine(TargetLook());
            StartCoroutine(TargetFire());
        }

        public IEnumerator TargetLook()
        {
            while (true)
            {
                if (_limit == true)
                {
                    var obj = MinigameSignals.Instance.onTarretSetObj?.Invoke(); // aynı anda atama yapıldığı için null referans veriyor.
                    if (_platform.GetComponent<Renderer>().material.color != obj.transform.GetChild(0).GetComponent<Renderer>().material.color)
                    {
                        rightTarret.transform.LookAt(obj.transform);
                        leftTarret.transform.LookAt(obj.transform);
                    }
                    yield return new WaitForFixedUpdate();
                }
                else yield break;
            }
        }

        public IEnumerator TargetFire()
        {
            while (true)
            {
                if (_limit == true)
                {
                    var obj = MinigameSignals.Instance.onTarretSetObj?.Invoke();
                    if (_platform.GetComponent<Renderer>().material.color != obj.transform.GetChild(0).GetComponent<Renderer>().material.color)
                    {
                        var insRightBullet = Instantiate(bullet, rightBarrel.transform.position, rightBarrel.transform.rotation);
                        var insLeftBullet = Instantiate(bullet, leftBarrel.transform.position, leftBarrel.transform.rotation);
                        insRightBullet.transform.DOMove(obj.transform.position, .1f);
                        insLeftBullet.transform.DOMove(obj.transform.position, .1f);
                    }
                    yield return new WaitForSeconds(.5f);
                }
                else yield break;
            }
            
        }
    }
}