using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Presentation.Lobby
{
    public class LobbyView : View<LobbyModel, LobbyModelData>
    {
        #region EventHandlers

        #endregion

        #region Fields

        [Header("LobbyCar")]
        [SerializeField]
        private LobbyCarView _lobbyCarView;
        public LobbyCarView LobbyCarView => _lobbyCarView;

        [Header("LobbyUI")]
        [SerializeField]
        private LobbyUIView _lobbyUIView;
        public LobbyUIView LobbyUIView => _lobbyUIView;

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


        #region Events: Add | Remove

        protected override void OnAddEvents()
        {
        }

        protected override void OnRemoveEvents()
        {
        }

        #endregion
    }
}
