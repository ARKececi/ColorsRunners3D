using System.Collections.Generic;
using Command.StackManager;
using Data.UnityObject;
using Data.ValueObject;
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
        public ListChangeCommand ListChangeCommand;
        public bool _randomfor;

        #endregion
        #region Serialized Variables

        [SerializeField] private GameObject player;
        [SerializeField] private GameObject PlayerObj;
        [SerializeField] private Transform Pool;

        #endregion
        #region Private Variables
        
        private float _random;

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
            for (int i = 0; i < 10; i++)
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
            if (StackListObj[0] != null)
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

        public void HelicopterPlatformStack()
        {
            int Count = StackListObj.Count;
            for (int i = 1; i <= Count - 1; i++)
            {
                Vector3 stackPos = StackListObj[0].transform.localPosition;
                if (_randomfor)
                {
                    _random = Random.Range(2, -2); 
                }
                float lerpobjz = Mathf.Lerp(StackListObj[i].transform.localPosition.z , stackPos.z + _random, StackData.LerpDelay * _random);
                StackListObj[i].transform.localPosition = new Vector3(stackPos.x, stackPos.y, lerpobjz);
            }
            _randomfor = false;
        }

        private void PoolInstantiate()
        {
            GameObject playerObj = Instantiate(PlayerObj);
            PoolListObj.Add(playerObj);
            playerObj.SetActive(false);
        }

        private void ListChange(GameObject obj, int list)
        {
            ListChangeCommand.ListChange(obj, list);
        }
    }
}