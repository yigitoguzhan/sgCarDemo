using SuperGearsGames.Demo.Layers.Application.Game;

namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    public class GameController : Controller<GameModel, GameModelData, GameView>
    {
        #region EventHandlers

        #endregion

        #region Controllers

        private GameplayController _gameplayController;
        private GameEndController _gameEndController;

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
            ShowInnerMVCs();
        }

        #endregion

        #region Override: OnHide

        protected override void OnHide()
        {
            HideInnerMVCs();
        }

        #endregion

        #endregion


        #region Initialize | DeInitialize: InnerMVCs

        #region Initialize: InnerMVCs

        private void InitializeInnerMVCs()
        {
            InitializeGameplayMVC();
        }

        #endregion

        #region Initialize : InnerMVCs: Gameplay

        private void InitializeGameplayMVC()
        {
            var modelData = new GameplayModelData(_model.GameData.GameplayData);
            var model = MVCFactory.CreateModel<GameplayModel, GameplayModelData>(modelData);
            _gameplayController = MVCFactory.CreateController<GameplayController, GameplayModel, GameplayModelData, GameplayView>(model, _view.GameplayView);
        }

        #endregion  
        
        #region Initialize: InnerMVCs: GameEnd

        private void InitializeGameEndMVC()
        {
            var modelData = new GameEndModelData(_model.GameData.GameplayData, _model.GameData.GameEndData);
            var model = MVCFactory.CreateModel<GameEndModel, GameEndModelData>(modelData);
            _gameEndController = MVCFactory.CreateController<GameEndController, GameEndModel, GameEndModelData, GameEndView>(model, _view.GameEndView);
        }

        #endregion

        #region DeInitialize: InnerMVCs

        private void DeInitializeInnerMVCs()
        {         
        }

        #endregion

        #region DeInitialize: InnerMVCs: Gameplay

        private void DeInitializeGameplayMVC()
        {
            _gameplayController.DeInit();
        }

        #endregion

        #region DeInitialize: InnerMVCs: GameEnd

        private void DeInitializeGameEndMVC()
        {
            _gameEndController.DeInit();
        }

        #endregion

        #endregion


        #region Show | Hide: InnerMVCs

        #region Show: InnerMVCs

        private void ShowInnerMVCs()
        {
            _gameplayController.Show();
        }

        #endregion


        #region Hide: InnerMVCs

        private void HideInnerMVCs()
        {
            _gameplayController.Hide();
            _gameEndController.Hide();
        }

        #endregion


        #endregion


        #region Event: OnGameplayStateChanged

        private void OnGameplayStateChanged(object sender, GameplayStateChangedEventArgs e)
        {
            if(e.State == GameplayState.Finished)
            {
                InitializeGameEndMVC();
                _gameEndController.Show();
            }
        } 

        #endregion

        #region Events: Add | Remove

        protected override void OnAddEvents()
        {
            _model.GameData.GameplayData.StateData.GameplayStateChangedEvent += OnGameplayStateChanged;
        }


        protected override void OnRemoveEvents()
        {
            _model.GameData.GameplayData.StateData.GameplayStateChangedEvent -= OnGameplayStateChanged;
        }

        #endregion
    }
}
