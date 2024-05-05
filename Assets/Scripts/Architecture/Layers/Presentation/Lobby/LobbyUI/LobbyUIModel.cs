using SuperGearsGames.Demo.Layers.Application.Lobby.Managers;

namespace SuperGearsGames.Demo.Layers.Presentation.Lobby
{
    #region ModelData

    public class LobbyUIModelData : ModelData
    {
        #region Constructor

        public LobbyUIModelData(LobbyState lobbyState)
        {
            LobbyState = lobbyState;
        }

        #endregion

        #region Data

        public LobbyState LobbyState { get; }

        #endregion
    }

    #endregion

    #region Model

    public class LobbyUIModel : Model<LobbyUIModelData>
    {
        #region Constructor

        public LobbyUIModel(LobbyUIModelData data) : base(data)
        {
        }

        #endregion

        #region Data

        public LobbyState LobbyState => Data.LobbyState;


        #endregion
    }

    #endregion
}
