using System;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Presentation
{
    public class TransitionUI : MonoBehaviour
    {
        #region Singleton Instance

        public static TransitionUI Instance { get; private set; }

        #endregion

        #region EventHandler

        public event EventHandler FinishTransitionEvent;

        #endregion

        #region Unity

        #region Unity: Awake

        private void Awake()
        {
            #region Instance

            var objectList = FindObjectsOfType(typeof(TransitionUI));
            if (objectList.Length > 1)
            {
                Destroy(gameObject);
            }

            Instance = this;

            #endregion

            FinishTransitionEvent += OnFinishTransitionEventRequested;
        }


        #endregion

        #endregion

        public void RequestFinishTransition()
        {
            FinishTransitionEvent.Invoke(this, EventArgs.Empty);
        }
        private void OnFinishTransitionEventRequested(object sender, EventArgs e)
        {
            gameObject.SetActive(false);
        }

    }
}