using SuperGearsGames.Demo.Layers.Data;

namespace SuperGearsGames.Demo.Layers.Application.Game.Managers
{
    public static class GameDataFactory
    {
        #region Data: Game: Create

        public static GameData CreateGameData(RaceConfigData currentRaceConfigData, CarConfigData currentCarConfigData)
        {
            var gameplayCarData = CreateGameplayCarData(currentCarConfigData);

            var gameplayRaceData = CreateRaceData(currentRaceConfigData, gameplayCarData);

            var gameplayData = CreateGameplayData(gameplayRaceData,new GameplayStateData(GameplayState.None), currentRaceConfigData);

            var gameEndData = CreateGameEndData(gameplayData.CurrentRaceData);

            return CreateGameData(gameplayData, gameEndData, currentRaceConfigData);
        }

        public static GameData CreateGameData(GameplayData gameplayData, GameEndData gameEndData, RaceConfigData currentRaceConfigData)
        {
            return new GameData(gameplayData, gameEndData, currentRaceConfigData);
        }

        #endregion


        #region Data: Gameplay: Create

        public static GameplayData CreateGameplayData(GameplayRaceData gameplayRaceData, GameplayStateData gameplayStateData, RaceConfigData raceConfigData)
        {
            return new GameplayData(gameplayRaceData, gameplayStateData, raceConfigData);
        }

        #endregion

        #region Data: GameEnd: Create

        public static GameEndData CreateGameEndData(GameplayRaceData gameplayRaceData)
        {
            return new GameEndData(gameplayRaceData);
        }

        #endregion

        #region Data: Race: Create

        public static GameplayRaceData CreateRaceData(RaceConfigData raceConfigData, GameplayCarData gameplayCarData)
        {
            return new GameplayRaceData(raceConfigData.RaceType, raceConfigData, gameplayCarData);
        }

        #endregion

        #region Data: Car: Create

        public static GameplayCarData CreateGameplayCarData(CarConfigData currentCarConfigData)
        {
            return new GameplayCarData(currentCarConfigData);
        }

        #endregion
    }
}
