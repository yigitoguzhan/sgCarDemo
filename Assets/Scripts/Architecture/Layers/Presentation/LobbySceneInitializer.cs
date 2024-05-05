using SuperGearsGames.Demo.Layers.Application.Lobby.Managers;
using SuperGearsGames.Demo.Layers.Application.Managers;
using SuperGearsGames.Demo.Layers.Presentation.Lobby;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Presentation
{
    public class LobbySceneInitializer : MonoBehaviour, ISceneInitializer
    {
        #region Controllers

        private LobbyController _lobbyController;

        #endregion

        #region Unity

        #region Unity: Awake

        private void Awake()
        {
            #region DontDestroyOnLoad

            var objectList = FindObjectsOfType(typeof(LobbySceneInitializer));
            if (objectList.Length > 1)
            {
                Destroy(gameObject);
            }

            //DontDestroyOnLoad(gameObject);

            #endregion
        }

        #endregion

        #endregion


        #region Show | Show -> OnShow

        public void Show()
        {
            gameObject.SetActive(true);

            OnShow();
        }

        private void OnShow()
        {
            _lobbyController.Show();
        }

        #endregion

        #region Hide | Hide -> OnHide

        public void Hide()
        {
            OnHide();
        }

        private void OnHide()
        {
            _lobbyController.Hide();

            //This should be stay at the bottom
            gameObject.SetActive(false);
        }

        #endregion

        #region Initialize

        public void Initialize()
        {
            LobbyManagerContainer.Instance.Init();
            LobbyManagerContainer.Instance.Launch();

            InitializeInnerMVCs();
            AddEvents();


            Show();
        } 

        #endregion

        #region Initialize: InnerMVCs

        private void InitializeInnerMVCs()
        {
            InitializeLobbyMVC();
        }

        #endregion

        #region Initialize: InnerMVCs: Lobby

        private void InitializeLobbyMVC()
        {
            var modelData = new LobbyModelData(AppManagerContainer.Instance.Car.ActiveCarData,AppManagerContainer.Instance.Car.CarDataList, LobbyManagerContainer.Instance.Lobby.LobbyState);
            var lobbyModel = MVCFactory.CreateModel<LobbyModel, LobbyModelData>(modelData);
            var lobbyView = MVCFactory.CreateView<LobbyView>(PresentationConfig.LOBBY_VIEW_PATH);
            _lobbyController = MVCFactory.CreateController<LobbyController, LobbyModel, LobbyModelData, LobbyView>(lobbyModel, lobbyView);
        }

        #endregion

        public void DeInitialize()
        {
            Hide();
            RemoveEvents();
            DeInitializeInnerMVCs();
        }

        #region DeInitialize: InnerMVCs

        private void DeInitializeInnerMVCs()
        {
            DeInitializeLobbyMVC();
        }

        #endregion

        #region DeInitialize: InnerMVCs: Lobby

        private void DeInitializeLobbyMVC()
        {
            _lobbyController.DeInit();
        }

        #endregion

        #region Events: Add | Remove

        private void AddEvents()
        {
        }

        private void RemoveEvents()
        {
        }

        #endregion
    }
}