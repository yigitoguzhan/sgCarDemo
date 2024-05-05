using SuperGearsGames.Demo.Layers.Application.Game;

namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    #region ModelData: Gameplay

    public class GameplayModelData : ModelData
    {
        #region Constructor

        public GameplayModelData(GameplayData data)
        {
            GameplayData = data;
        }

        #endregion

        #region Data

        public GameplayData GameplayData { get; }

        #endregion
    }

    #endregion
    public class GameplayModel : Model<GameplayModelData>
    {
        #region Constructor

        public GameplayModel(GameplayModelData data) : base(data)
        {
        }

        #endregion

        #region Data

        public GameplayData GameplayData => Data.GameplayData;
     
        #endregion
    }
}
