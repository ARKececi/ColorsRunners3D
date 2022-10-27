using System.Collections;
using System.Collections.Generic;
using Command.StackManager;
using Data.UnityObject;
using Data.ValueObject;
using DG.Tweening;
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
        public bool _randomfor;

        #endregion
        #region Serialized Variables

        [SerializeField] private GameObject player;
        [SerializeField] private GameObject PlayerObj;
        [SerializeField] private Transform Pool;

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
            for (int i = 0; i < 40; i++)
            {
                PoolInstantiate();
            }
            
            for (int i = 0; i < 40; i++)
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
            float ranInt = 0.13f;
            for (int i = 0; i < 20; i++)
            {
                //var random = Random.Range(0.0f, 2.0f);
                
                yield return new WaitForSeconds(ranInt);
                //int stackObjListCount = StackListObj.Count;
                Vector3 position = StackListObj[0].transform.position;
                Vector3 lastPosition = StackListObj[1].transform.position;
                player.transform.position = lastPosition;
                var obj = StackListObj[0];
                StackListObj.Remove(StackListObj[0]);
                ranInt += 0.15f;
                //obj.transform.DOMoveZ(position.z + random, random);

            }
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