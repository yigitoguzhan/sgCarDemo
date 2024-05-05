using SuperGearsGames.Demo.Layers.Data.Repositories;

namespace SuperGearsGames.Demo.Layers.Presentation.Lobby
{
    #region ModelData

    public class LobbyCarModelData : ModelData
    {
        #region Constructor

        public LobbyCarModelData(CarData activeCarData)
        {
            ActiveCarData = activeCarData;
        }

        #endregion

        #region Data

        public CarData ActiveCarData { get; }

        #endregion
    }

    #endregion

    #region Model

    public class LobbyCarModel : Model<LobbyCarModelData>
    {
        #region Constructor

        public LobbyCarModel(LobbyCarModelData data) : base(data)
        {
        }

        #endregion

        #region Data

        public CarData ActiveCarData => Data.ActiveCarData;


        #endregion
    } 

    #endregion
}
