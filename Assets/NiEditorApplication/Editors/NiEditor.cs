using System;
using System.Collections.Generic;
using Fdb.Database;
using Fdb.Enums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NiEditorApplication.Editor
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

        public virtual void Activate()
        {
            foreach (var editor in Editors)
            {
                editor.gameObject.SetActive(false);
            }

            gameObject.SetActive(true);
        }

        public void FixedUpdate()
        {
            ActionButton.interactable = FdbEditor.Database != default;
        }

        protected static Row NewRow(Table table)
        {
            var fields = new Field[table.Structure.Length];

            for (var index = 0; index < fields.Length; index++)
            {
                var field = table.Structure[index];

                fields[index] = new Field(field.Type, 0);

                switch (field.Type)
                {
                    case DataType.Nothing:
                        fields[index].Value = 0;
                        break;
                    case DataType.Integer:
                        fields[index].Value = 0;
                        break;
                    case DataType.Unknown1:
                        fields[index].Value = 0;
                        break;
                    case DataType.Float:
                        fields[index].Value = 0f;
                        break;
                    case DataType.Text:
                        fields[index].Value = "";
                        break;
                    case DataType.Boolean:
                        fields[index].Value = false;
                        break;
                    case DataType.Bigint:
                        fields[index].Value = 0;
                        break;
                    case DataType.Unknown2:
                        fields[index].Value = 0;
                        break;
                    case DataType.Varchar:
                        fields[index].Value = "";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return new Row(fields);
        }
    }
}