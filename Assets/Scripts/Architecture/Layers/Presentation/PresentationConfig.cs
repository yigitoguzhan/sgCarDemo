using SuperGearsGames.Demo.Layers.Application.Lobby.Managers;

namespace SuperGearsGames.Demo.Layers.Presentation
{
    public static class PresentationConfig
    {
        #region View Paths

        #region Views: Lobby

        public const string LOBBY_VIEW_PATH = "Views/Lobby/LobbyView";

        #endregion

        #region Views: Game

        public const string GAME_VIEW_PATH = "Views/Game/GameView";

        #region Gameplay

        public const string GAMEPLAY_CAR_VIEW_PATH = "Views/Game/Gameplay/GameplayRace/GameplayCar/GameplayCarView";

        #endregion

        #endregion

        #endregion

        #region Lobby

        public const LobbyState DEFAULT_LOBBY_STATE = LobbyState.Home;

        #endregion

    }
}
