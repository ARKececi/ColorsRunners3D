using System;
using System.Collections.Generic;
using UnityEngine;
using Color = Enums.Color;

namespace Controllers.PlayerObjectsManager
{
    public class PlayerObjectsController : MonoBehaviour
    {
        #region Self Variables
        #region public Variables

        

        #endregion
        #region Serialized Variables

        [SerializeField] private GameObject door;
        [SerializeField] private List<Material> materials;

        #endregion
        #region Private Variables

        

        #endregion
        #endregion

        public void Comparison(GameObject door)
        {
            string removeName = " (Instance)";
            string materialName = door.GetComponent<Renderer>().material.name;
            int i = materialName.Length - removeName.Length;
            materialName = materialName.Remove(i, removeName.Length);
            Color index = (Color)Enum.Parse(typeof(Color), materialName);
            ColorChange(index);
        }
        
        public void ColorChange(Color color)
        {
            Material material = materials[(int)color];
            transform.GetChild(0).GetComponent<Renderer>().material = material;
        }
    }
}