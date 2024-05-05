using SuperGearsGames.Demo.Layers.Application.Managers;
using System;

namespace SuperGearsGames.Demo.Layers.Application.Lobby.Managers
{
    public class LobbyManager : Manager
    {
        #region EventHandlers

        public event EventHandler<LobbyStateChangedEventArgs> LobbyStateChangedEvent;

        #endregion

        #region States

        public LobbyState LobbyState { get; private set; }

        #endregion

        #region Override: OnBegin | OnRegister | OnUnRegister | OnEnd

        protected override void OnBegin()
        {
            LobbyState = LobbyState.Garage;
        }

        protected override void OnRegister()
        {
            AddEvents();
        }

        protected override void OnUnRegister()
        {
            RemoveEvents();
        }

        protected override void OnEnd()
        {
        }

        #endregion


        #region LobbyState: Change

        public void ChangeLobbyState(LobbyState state)
        {
            LobbyState = state;

            LobbyStateChangedEvent.Invoke(this, new LobbyStateChangedEventArgs(LobbyState));
        }

        #endregion


        #region Events: Add | Remove

        private void AddEvents()
        {
        }

        private void RemoveEvents()
        {
        }

        #endregion
    }
}