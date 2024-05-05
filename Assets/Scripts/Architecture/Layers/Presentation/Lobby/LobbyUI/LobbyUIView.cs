using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SuperGearsGames.Demo.Layers.Presentation.Lobby
{
    public class LobbyUIView : View<LobbyUIModel, LobbyUIModelData>
    {
        #region EventHandlers

        public event EventHandler PlayBtnClickedEvent;

        #endregion

        #region Fields

        [Header("Buttons")]
        [SerializeField]
        private Button _btnGarage;
        [SerializeField]
        private Button _btnPlay;
        [SerializeField]
        private Button _btnShop;

        #endregion

        #region Override

        #region Override: OnShow

        protected override void OnShow()
        {
            Init();
        }

        #endregion

        #region Override: OnRefresh

        protected override void OnRefresh()
        {
        }

        #endregion

        #region Override: OnHide

        protected override void OnHide()
        {
        }

        #endregion

        #endregion


        #region Init

        private void Init()
        {
        }

        #endregion


        #region Event: OnBtnPlayClicked

        public void OnPlayBtnClicked()
        {
            PlayBtnClickedEvent?.Invoke(this, EventArgs.Empty);   
        }

        #endregion

        #region Events: Add | Remove

        protected override void OnAddEvents()
        {
            _btnPlay.onClick.AddListener(OnPlayBtnClicked);
        }

        protected override void OnRemoveEvents()
        {
            _btnPlay.onClick.RemoveAllListeners();
        }

        #endregion
    }
}
