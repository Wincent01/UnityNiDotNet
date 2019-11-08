using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace NiEditorApplication.Editor
{
    public class ExtendedButton : MonoBehaviour, IPointerClickHandler
    {
        public event Action LeftClick;
        public event Action MiddleClick;
        public event Action RightClick;

        public void OnPointerClick(PointerEventData eventData)
        {
            Debug.Log(eventData.button);
            switch (eventData.button)
            {
                case PointerEventData.InputButton.Left:
                    LeftClick?.Invoke();
                    break;
                case PointerEventData.InputButton.Middle:
                    MiddleClick?.Invoke();
                    break;
                case PointerEventData.InputButton.Right:
                    RightClick?.Invoke();
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}