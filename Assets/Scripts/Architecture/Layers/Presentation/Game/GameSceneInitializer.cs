using SuperGearsGames.Demo.Layers.Application.Game.Managers;
using SuperGearsGames.Demo.Layers.Presentation.Game;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Presentation
{
    public class GameSceneInitializer : MonoBehaviour, ISceneInitializer
    {
        #region Controllers

        public GameController GameController { get; private set; }

        #endregion

        #region Unity

        #region Unity: Awake

        private void Awake()
        {
            #region DontDestroyOnLoad

            var objectList = FindObjectsOfType(typeof(GameSceneInitializer));
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
            GameController.Show();
        }

        #endregion

        #region Hide | Hide -> OnHide

        public void Hide()
        {
            OnHide();
        }

        private void OnHide()
        {
            GameController.Hide();

            //This should be stay at the bottom
            gameObject.SetActive(false);
        }

        #endregion


        #region Initialize

        public void Initialize()
        {
            GameManagerContainer.Instance.Init();

            InitializeInnerMVCs();
            AddEvents();
            Show();
            GameManagerContainer.Instance.Launch();
        }

        #endregion

        #region Initialize: InnerMVCs

        private void InitializeInnerMVCs()
        {
            InitializeGameMVC();
        }

        #endregion

        #region Initialize: InnerMVCs: Game

        private void InitializeGameMVC()
        {
            var gameData = GameManagerContainer.Instance.Game.GameData;
            var modelData = new GameModelData(gameData);
            var model = MVCFactory.CreateModel<GameModel, GameModelData>(modelData);
            var view = MVCFactory.CreateView<GameView>(PresentationConfig.GAME_VIEW_PATH);
            GameController = MVCFactory.CreateController<GameController, GameModel, GameModelData, GameView>(model, view);
        }

        #endregion


        #region DeInitialize

        public void DeInitialize()
        {
            Hide();
            RemoveEvents();
            DeInitializeInnerMVCs();

            GameManagerContainer.Instance.End();
            GameManagerContainer.Instance.DeInit();
        }

        #endregion

        #region DeInitialize: InnerMVCs

        private void DeInitializeInnerMVCs()
        {
            DeInitializeGameMVC();
        }

        #endregion

        #region DeInitialize: InnerMVCs: Game

        private void DeInitializeGameMVC()
        {
            var goView = GameController.View.gameObject;
            GameController.DeInit();

            Destroy(goView);
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