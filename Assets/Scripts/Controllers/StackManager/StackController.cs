using System.Collections;
using System.Collections.Generic;
using Command.StackManager;
using Data.UnityObject;
using Data.ValueObject;
using DG.Tweening;
using Signals;
using UnityEngine;

namespace Controllers.StackManager
{
    public class StackController : MonoBehaviour
    {
        #region Self Variables
        #region Public Variables

        [Header("Data")] public StackData StackData;
        public List<GameObject> StackListObj;
        public List<GameObject> PoolListObj;
        public List<GameObject> MinigameObjList;
        public ListChangeCommand ListChangeCommand;

        #endregion
        #region Serialized Variables

        [SerializeField] private GameObject player;
        [SerializeField] private GameObject PlayerObj;
        [SerializeField] private Transform Pool;
        [SerializeField] private GameObject MinigamePlatform;

        #endregion
        #region Private Variables

        #endregion
        #endregion

        private void Awake()
        {
            StackData = GetStackData();
            ListChangeCommand = new ListChangeCommand(ref StackListObj, ref PoolListObj, transform, Pool,
                player.transform, ref StackData);
        }

        private void Start()
        {
            for (int i = 0; i < 6; i++)
            {
                PoolInstantiate();
            }
            
            for (int i = 0; i < 6; i++)
            {
                 ListChange(PoolListObj[0], 2);
            }
        }

        private StackData GetStackData() => Resources.Load<SO_StackData>("Data/SO_StackData").StackData;

        public void PositionUpdate()
        {
            int count = StackListObj.Count;
            if (count != 0)
            {
                StackListObj[0].transform.position = player.transform.position;
            }
        }

        public void MoveStack()
        {
            int Count = StackListObj.Count;
            for (int i = 1; i <= Count - 1; i++)
            {
                Vector3 stackPos = StackListObj[i - 1].transform.localPosition;
                float lerpObjx = Mathf.Lerp(StackListObj[i].transform.localPosition.x, stackPos.x, StackData.LerpDelay);
                float lerpobjz = Mathf.Lerp(StackListObj[i].transform.localPosition.z - StackData.StackBetween, stackPos.z, StackData.LerpDelay);
                float lerpobjy = Mathf.Lerp(StackListObj[i].transform.localPosition.y, stackPos.y, StackData.LerpDelay);
                StackListObj[i].transform.localPosition = new Vector3(lerpObjx, lerpobjy, lerpobjz);
            }
        }

        public IEnumerator HelicopterPlatformStack()
        {
            float ranSec = 0.07f;
            float boundary = player.transform.position.z;
            while (StackListObj.Count > 0)
            {
                if (player.transform.position.z < boundary - 3 )
                {
                    ranSec = 0.14f;
                }
                else if (player.transform.position.z > boundary + 1)
                {
                    ranSec = 0.07f;
                }
                if (StackListObj.Count != 1)
                {
                    Transform lastPosition = StackListObj[1].transform;
                    player.transform.position = lastPosition.position;
                }
                var obj = StackListObj[0];
                MinigameObjList.Add(obj);
                StackListObj.Remove(obj);
                
                yield return new WaitForSeconds(ranSec);
            }
            CoreGameSignals.Instance.onFinish?.Invoke();
            StackSignals.Instance.onPlatformClose?.Invoke();
        }

        private void PoolInstantiate()
        {
            GameObject playerObj = Instantiate(PlayerObj);
            PoolListObj.Add(playerObj);
            playerObj.transform.SetParent(Pool);
            playerObj.SetActive(false);
        }

        private void ListChange(GameObject obj, int list)
        {
            ListChangeCommand.ListChange(obj, list);
        }
    }
}