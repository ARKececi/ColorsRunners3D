using System.Collections.Generic;
using Data.ValueObject;
using UnityEngine;

namespace Command.StackManager
{
    public class StackAddCommand
    {
        #region Self Variables
        #region Private Variables

        private List<GameObject> _listObj;
        private Transform _transform;
        private StackData _stackData;

        #endregion
        #endregion

        public StackAddCommand(ref List<GameObject> listObj, Transform transform,ref StackData stackData)
        {
            _listObj = listObj;
            _transform = transform;
            _stackData = stackData;
        }
        
        public void StackAddList(GameObject obj)
        {
            Vector3 newPos = _transform.position;
            _listObj.Add(obj);
            var index =_listObj.IndexOf(obj);
            newPos.z -= index - (_stackData.StackBetween * index);
            obj.transform.position = newPos;
        }
    }
}