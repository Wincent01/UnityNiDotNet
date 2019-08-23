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
        public Button PullInButton;
        public Button PullOutButton;
        public RectTransform InPosition;
        public RectTransform OutPosition;
        public float MoveSpeed;
        public GameObject RaycastCover;

        private RectTransform _rectTransform;
        protected bool Moving;

        protected static bool CanMove => true; //Editors.All(e => !e.Moving);

        public void Start()
        {
            _rectTransform = GetComponent<RectTransform>();
            Editors.Add(this);
        }

        public void FixedUpdate()
        {
            //_rectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
        }
    }
}