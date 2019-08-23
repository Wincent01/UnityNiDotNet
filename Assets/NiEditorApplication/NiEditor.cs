using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NiEditorApplication
{
    public class NiEditor : MonoBehaviour
    {
        public static readonly List<NiEditor> Editors = new List<NiEditor>();
        
        [Header("Header")]
        public TextMeshProUGUI ApplicationTitle;
        public GameObject RaycastCover;
        public Button ActionButton;

        private RectTransform _rectTransform;

        public void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            Editors.Add(this);
            
            ActionButton.onClick.AddListener(() =>
            {
                foreach (var editor in Editors)
                {
                    editor.gameObject.SetActive(false);
                }

                gameObject.SetActive(true);
            });
        }

        public void Activate()
        {
            foreach (var editor in Editors)
            {
                editor.gameObject.SetActive(false);
            }

            gameObject.SetActive(true);
        }

        public void FixedUpdate()
        {
            //_rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        }
    }
}