using System;

namespace SuperGearsGames.Demo.Layers.Application.Lobby.Managers
{
    public class LobbyStateChangedEventArgs : EventArgs
    {
        #region Constructor

        public LobbyStateChangedEventArgs(LobbyState state)
        {
            State = state;
        }

        #endregion

        public LobbyState State { get; }       
    }
}