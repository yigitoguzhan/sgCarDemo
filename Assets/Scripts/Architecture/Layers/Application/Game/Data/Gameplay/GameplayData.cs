using SuperGearsGames.Demo.Layers.Data;
using System;

namespace SuperGearsGames.Demo.Layers.Application.Game
{
    public class GameplayData
    {
        #region Constructor

        public GameplayData(GameplayRaceData gameplayRaceData,GameplayStateData gameplayStateData, RaceConfigData raceConfigData)
        {
            CurrentRaceData = gameplayRaceData;
            StateData = gameplayStateData;
            RaceConfigData = raceConfigData;
        }

        #endregion

        #region Data

        public GameplayRaceData CurrentRaceData { get; private set; }
        public GameplayStateData StateData { get; private set; }
        public RaceConfigData RaceConfigData { get; }

        #endregion
    }

    #region StateData

    public class GameplayStateData
    {
        #region EventHandlers

        public event EventHandler<GameplayStateChangedEventArgs> GameplayStateChangedEvent;

        #endregion

        #region Constructor

        public GameplayStateData(GameplayState state)
        {
            State = state;
        }

        #endregion

        #region Data

        public GameplayState State { get; private set; }

        #endregion

        #region State: Change

        /// <summary>
        ///     IMPORTANT: Only call from GameplayManager
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(GameplayState state)
        {
            State = state;
            GameplayStateChangedEvent?.Invoke(this, new GameplayStateChangedEventArgs(State));
        }

        #endregion
    }

    #endregion
}
