using SuperGearsGames.Demo.Layers.Data;

namespace SuperGearsGames.Demo.Layers.Application.Game
{
    public class GameplayRaceData
    {
        #region Constructor

        public GameplayRaceData(RaceType raceType, RaceConfigData configData, GameplayCarData carData)
        {
            RaceType = raceType;

            CarData = carData;

            DidEnd = false;

            ConfigData = configData;
        }

        #endregion

        #region Data

        public RaceType RaceType { get; protected set; }
        public GameplayCarData CarData { get; }
        public bool DidEnd { get; private set; }
        public RaceConfigData ConfigData { get; }

        #endregion

        #region Race: End

        public void EndRound()
        {
            DidEnd = true;
        }

        #endregion
    }
}
