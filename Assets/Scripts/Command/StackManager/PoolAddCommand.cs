using System.Collections.Generic;
using UnityEngine;

namespace Command.StackManager
{
    public class PoolAddCommand
    {
        #region Self Variables
        #region Private Variables

        private List<GameObject> _listObj;
        private Transform _transform;

        #endregion
        #endregion

        public PoolAddCommand(ref List<GameObject> listObj, Transform transform)
        {
            _listObj = listObj;
            _transform = transform;
        }

        public void PoolAddList(GameObject obj)
        {
            obj.transform.SetParent(_transform);
            var index = _listObj.Count;
            obj.transform.name = "PlayerObj " + "(" + index + ")";
            _listObj.Add(obj);
            obj.SetActive(false);
        }
    }
}