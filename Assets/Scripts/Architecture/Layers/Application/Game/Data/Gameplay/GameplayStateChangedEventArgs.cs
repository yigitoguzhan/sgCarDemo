using System;

namespace SuperGearsGames.Demo.Layers.Application.Game
{
    public class GameplayStateChangedEventArgs: EventArgs
    {
        #region Constructor

        public GameplayStateChangedEventArgs(GameplayState state)
        {
            State = state;
        }

        #endregion

        public GameplayState State { get; private set; }
    }
}