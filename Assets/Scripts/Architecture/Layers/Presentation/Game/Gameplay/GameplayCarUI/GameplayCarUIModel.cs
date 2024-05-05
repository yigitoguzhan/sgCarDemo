using SuperGearsGames.Demo.Layers.Application.Game;

namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    #region ModelData

    public class GameplayCarUIModelData : ModelData
    {
        #region Constructor

        public GameplayCarUIModelData(GameplayCarData carData)
        {
            CarData = carData;
        }

        #endregion

        #region Data

        public GameplayCarData CarData { get; }

        #endregion
    }

    #endregion

    public class GameplayCarUIModel : Model<GameplayCarUIModelData>
    {
        #region Constructor

        public GameplayCarUIModel(GameplayCarUIModelData data) : base(data)
        {
        }

        #endregion

        #region Data

        public GameplayCarData CarData => Data.CarData;

        #endregion
    }
}
