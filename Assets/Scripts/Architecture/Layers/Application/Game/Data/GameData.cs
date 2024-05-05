using SuperGearsGames.Demo.Layers.Application.Game.Managers;
using SuperGearsGames.Demo.Layers.Data;

namespace SuperGearsGames.Demo.Layers.Application.Game
{
    public class GameData 
    {
        #region Constructor

        public GameData(GameplayData gameplayData, GameEndData gameEndData, RaceConfigData raceConfigData)
        {
            GameplayData = gameplayData;
            GameEndData = gameEndData;
            RaceConfigData = raceConfigData;
        }

        #endregion

        #region Data

        public GameplayData GameplayData { get; }
        public GameEndData GameEndData { get; }

        public RaceConfigData RaceConfigData { get; }

        #endregion
    }
}
