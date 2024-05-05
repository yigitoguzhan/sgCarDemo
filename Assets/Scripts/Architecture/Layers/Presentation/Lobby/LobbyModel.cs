using SuperGearsGames.Demo.Layers.Application.Lobby.Managers;
using SuperGearsGames.Demo.Layers.Data.Repositories;
using System.Collections.Generic;

namespace SuperGearsGames.Demo.Layers.Presentation.Lobby
{
    #region ModelData

    public class LobbyModelData : ModelData
    {
        #region Constructor

        public LobbyModelData(CarData activeCarData, List<CarData> carDataList, LobbyState lobbyState)
        {
            ActiveCarData = activeCarData;
            CarDataList = carDataList;
            LobbyState = lobbyState;
        }

        #endregion

        #region Data

        public CarData ActiveCarData { get; }
        public List<CarData> CarDataList { get; }
        public LobbyState LobbyState { get; private set; }

        #endregion

        #region LobbyState: Set

        public void SetLobbyState(LobbyState lobbyState)
        {
            LobbyState = lobbyState;
        }

        #endregion
    }

    #endregion

    #region Model

    public class LobbyModel : Model<LobbyModelData>
    {
        #region Constructor

        public LobbyModel(LobbyModelData data) : base(data)
        {
        }

        #endregion

        #region Data

        public CarData ActiveCarData => Data.ActiveCarData;
        public List<CarData> CarDataList => Data.CarDataList;
        public LobbyState LobbyState => Data.LobbyState;

        #endregion

        #region LobbyState: Set

        public void SetLobbyState(LobbyState lobbyState)
        {
            Data.SetLobbyState(lobbyState);
        }

        #endregion
    }

    #endregion
}