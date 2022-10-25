using UnityEngine;

namespace Controllers.PlayerObjectsManager
{
    public class PlayerObjectsController : MonoBehaviour
    {
        #region Self Variables
        #region public Variables

        

        #endregion
        #region Serialized Variables

        

        #endregion
        #region Private Variables

        

        #endregion
        #endregion

        public void ColorChange()
        {
            Color color;
            ColorUtility.TryParseHtmlString("#FF0700", out color);
            transform.GetChild(0).GetComponent<Renderer>().material.color = color;
        }
    }
}