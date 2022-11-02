using System;
using System.Collections.Generic;
using Data.UnityObject;
using Data.ValueObject;
using DG.Tweening;
using Signals;
using UnityEditor;
using UnityEngine;
using UnityEngine.Rendering;
using Color = Enums.Color;

namespace Controllers.PlayerObjectsManager
{
    public class PlayerObjectsController : MonoBehaviour
    {
        #region Self Variables
        #region public Variables

        #endregion
        #region Serialized Variables
        
        [SerializeField] private List<Material> materials;
        [SerializeField] private Animator animator;

        #endregion
        #region Private Variables

        private Material _material;
        private ObjectData _objectData;

        #endregion
        #endregion

        private void Awake()
        {
            _objectData = GetObjectData();
        }

        private ObjectData GetObjectData(){return Resources.Load<SO_ObjectData>("Data/SO_ObjectData").ObjectData;}
        
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

        public void MinigameControl()
        {
            //DataSignals();
            CoreGameSignals.Instance.minigameState?.Invoke("HelicopterMinigame");
            float distance = _objectData.distance;
            float i = _objectData.quantity;
            if (transform.position.x < 0)
            {
                transform.DOMoveX(-1.5f, .5f);
            }
            else
            {
                transform.DOMoveX(1.5f, .8f);
            }
            if (distance >= 6)
            {
                i = -.5f;
            }
            else if (distance <= 4)
            {
                i = .5f;
            }
            distance += i;
            transform.DOMoveZ(transform.position.z + distance, 1);
            _objectData.distance = distance;
            _objectData.quantity = i;
        }

        public void Transparent()
        {
            _material = transform.GetChild(0).GetComponent<Renderer>().material;
            _material.SetFloat("_Surface", (float)BaseShaderGUI.SurfaceType.Transparent);
            _material.SetFloat("_Blend", (float)BaseShaderGUI.BlendMode.Alpha);

        }
    }
}