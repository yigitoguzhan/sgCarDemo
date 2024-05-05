using SuperGearsGames.Demo.Layers.Application.Game;

namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    #region ModelData

    public class GameModelData : ModelData
    {
        #region Constructor

        public GameModelData(GameData data)
        {
            GameData = data;
        }

        #endregion

        #region Data

        public GameData GameData { get; }

        #endregion
    }

    #endregion

    public class GameModel : Model<GameModelData>
    {
        #region Constructor

        public GameModel(GameModelData data) : base(data)
        {
        }

        #endregion

        #region Data

        public GameData GameData => Data.GameData;

        #endregion
    }
}
