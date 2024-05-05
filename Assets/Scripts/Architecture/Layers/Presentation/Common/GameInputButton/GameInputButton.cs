using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SuperGearsGames.Demo.Layers.Presentation.Common
{
    public class GameInputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        #region EventHandler

        public event EventHandler ButtonPressedEvent;
        public event EventHandler ButtonReleasedEvent;

        #endregion

        public void OnPointerDown(PointerEventData eventData)
        {
            ButtonPressedEvent?.Invoke(this, EventArgs.Empty);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            ButtonReleasedEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}
