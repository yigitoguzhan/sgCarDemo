using SuperGearsGames.Demo.Layers.Application.Lobby.Managers;

namespace SuperGearsGames.Demo.Layers.Presentation.Lobby
{
    public class LobbyController : Controller<LobbyModel, LobbyModelData, LobbyView>
    {
        #region Controllers

        private LobbyCarController _lobbyCarController;
        private LobbyUIController _lobbyUIController;

        #endregion

        #region Override

        #region Override: OnInit

        protected override void OnInit()
        {
            InitializeInnerMVCs();
        }

        #endregion

        #region Override: OnDeInit

        protected override void OnDeInit()
        {
            DeInitializeInnerMVCs();
        }

        #endregion

        #region Override: OnShow

        protected override void OnShow()
        {
            _lobbyCarController.Show();
            _lobbyUIController.Show();
        }

        #endregion

        #region Override: OnHide

        protected override void OnHide()
        {
            _lobbyCarController.Hide();
            _lobbyUIController.Hide();
        }

        #endregion

        #endregion

        #region Initialize | DeInitialize: InnerMVCs

        #region Initialize: InnerMVCs

        private void InitializeInnerMVCs()
        {
            InitializeLobbyCarMVC();
            InitializeLobbyUIMVC();
        }

        #endregion

        #region Initialize: InnerMVCs: LobbyCar

        private void InitializeLobbyCarMVC()
        {
            var modelData = new LobbyCarModelData(_model.ActiveCarData);
            var model = MVCFactory.CreateModel<LobbyCarModel, LobbyCarModelData>(modelData);
            _lobbyCarController = MVCFactory.CreateController<LobbyCarController, LobbyCarModel, LobbyCarModelData, LobbyCarView>(model, _view.LobbyCarView);
        }

        #endregion

        #region Initialize: InnerMVCs: LobbyUI

        private void InitializeLobbyUIMVC()
        {
            var modelData = new LobbyUIModelData(_model.LobbyState);
            var model = MVCFactory.CreateModel<LobbyUIModel, LobbyUIModelData>(modelData);
            _lobbyUIController = MVCFactory.CreateController<LobbyUIController, LobbyUIModel, LobbyUIModelData, LobbyUIView>(model, _view.LobbyUIView);
        }

        #endregion


        #region DeInitialize: InnerMVCs

        private void DeInitializeInnerMVCs()
        {
            DeInitializeLobbyCarMVC();
            DeInitializeLobbyUIMVC();
        }

        #endregion

        #region DeInitialize: InnerMVCs: LobbyCar

        private void DeInitializeLobbyCarMVC()
        {
            _lobbyCarController.DeInit();
        }

        #endregion

        #region DeInitialize: InnerMVCs: LobbyUI

        private void DeInitializeLobbyUIMVC()
        {
            _lobbyUIController.DeInit();
        }

        #endregion

        #endregion

        #region Event: OnLobbyStateChanged

        private void OnLobbyStateChanged(object sender, LobbyStateChangedEventArgs e)
        {
            //_menuContainerController.ChangeLobbyState(e.Menu);
            //TODO: ADD CAMERA MOVEMENT LOGIC
        }

        #endregion

        #region Events: Add | Remove

        protected override void OnAddEvents()
        {
            LobbyManagerContainer.Instance.Lobby.LobbyStateChangedEvent += OnLobbyStateChanged;
        }

        protected override void OnRemoveEvents()
        {
            LobbyManagerContainer.Instance.Lobby.LobbyStateChangedEvent -= OnLobbyStateChanged;
        }

        #endregion
    }
}
