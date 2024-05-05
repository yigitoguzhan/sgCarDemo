using System;

namespace SuperGearsGames.Demo.Layers.Application.Game.Managers
{
    public class GameEndData
    {
        #region Constructor

        public GameEndData(GameplayRaceData gameplayRaceData)
        {
            RaceData = gameplayRaceData;
        }

        #endregion

        #region Data

        public GameplayRaceData RaceData { get; private set; }

        #endregion
    }
}