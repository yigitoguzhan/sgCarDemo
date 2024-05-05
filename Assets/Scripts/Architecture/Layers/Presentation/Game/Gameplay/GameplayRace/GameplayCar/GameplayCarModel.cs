using SuperGearsGames.Demo.Layers.Application.Game;

namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    #region ModelData

    public class GameplayCarModelData : ModelData
    {
        #region Constructor

        public GameplayCarModelData(GameplayCarData carData)
        {
            CarData = carData;
        }

        #endregion

        #region Data

        public GameplayCarData CarData { get; }

        #endregion
    }

    #endregion

    #region Model

    public class GameplayCarModel : Model<GameplayCarModelData>
    {
        #region Constructor

        public GameplayCarModel(GameplayCarModelData data) : base(data)
        {
        }

        #endregion

        #region Data

        public GameplayCarData CarData => Data.CarData;

        #endregion
    }

    #endregion
}
