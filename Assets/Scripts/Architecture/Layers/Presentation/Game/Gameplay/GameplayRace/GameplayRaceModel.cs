using SuperGearsGames.Demo.Layers.Application.Game;

namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    #region ModelData: GameplayRace

    public class GameplayRaceModelData : ModelData
    {
        #region Constructor

        public GameplayRaceModelData(GameplayData gameplayData)
        {
            GameplayData = gameplayData;
        }

        #endregion

        #region Data

        public GameplayData GameplayData { get; }

        #endregion
    }

    #endregion

    public class GameplayRaceModel : Model<GameplayRaceModelData>
    {
        #region Constructor

        public GameplayRaceModel(GameplayRaceModelData data) : base(data)
        {
        }

        #endregion

        #region Data

        public GameplayRaceData RaceData => Data.GameplayData.CurrentRaceData;

        #endregion
    }
}
