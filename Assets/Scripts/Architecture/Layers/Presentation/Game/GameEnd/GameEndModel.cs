using SuperGearsGames.Demo.Layers.Application.Game.Managers;
using SuperGearsGames.Demo.Layers.Application.Game;

namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    #region ModelData

    public class GameEndModelData : ModelData
    {
        #region Constructor

        public GameEndModelData(GameplayData gameplayData, GameEndData gameEndData)
        {
            GameplayData = gameplayData;
            GameEndData = gameEndData;
        }

        #endregion

        #region Data

        public GameplayData GameplayData { get; }
        public GameEndData GameEndData { get; }

        #endregion
    }

    #endregion

    public class GameEndModel : Model<GameEndModelData>
    {
        #region Constructor

        public GameEndModel(GameEndModelData data) : base(data)
        {
        }

        #endregion

        #region Data

        public GameplayData GameplayData => Data.GameplayData;
        public GameEndData GameEndData => Data.GameEndData;

        #endregion
    }
}
