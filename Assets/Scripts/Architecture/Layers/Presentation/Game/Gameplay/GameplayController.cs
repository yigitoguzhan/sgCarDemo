namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    public class GameplayController : Controller<GameplayModel, GameplayModelData, GameplayView>
    {
        #region EventHandlers

        #endregion

        #region Controllers

        private GameplayRaceController _raceController;
        private GameplayRaceInfoOverlayController _raceInfoOverlayController;
        private GameplayCarUIController _carUIController;

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
            InitializeRaceMVC();
            InitializeCarUIMVC();
            InitializeRaceInfoOverlayMVC();
        }

        #endregion


        #region Initialize: InnerMVCs: Race

        private void InitializeRaceMVC()
        {
            var modelData = new GameplayRaceModelData(_model.GameplayData);
            var model = MVCFactory.CreateModel<GameplayRaceModel, GameplayRaceModelData>(modelData);
            var view = _view.RaceView;
            _raceController = MVCFactory.CreateController<GameplayRaceController, GameplayRaceModel, GameplayRaceModelData, GameplayRaceView>(model, view);
        }

        #endregion

        #region Initialize: InnerMVCs: CarUI

        private void InitializeCarUIMVC()
        {
            var modelData = new GameplayCarUIModelData(_model.GameplayData.CurrentRaceData.CarData);
            var model = MVCFactory.CreateModel<GameplayCarUIModel, GameplayCarUIModelData>(modelData);
            var view = _view.CarUIView;
            _carUIController = MVCFactory.CreateController<GameplayCarUIController, GameplayCarUIModel, GameplayCarUIModelData, GameplayCarUIView>(model, view);
        }

        #endregion

        #region Initialize: InnerMVCs: RaceInfoOverlay

        private void InitializeRaceInfoOverlayMVC()
        {
            var modelData = new GameplayRaceInfoOverlayModelData(_model.GameplayData);
            var model = MVCFactory.CreateModel<GameplayRaceInfoOverlayModel, GameplayRaceInfoOverlayModelData>(modelData);
            var view = _view.GameplayRaceInfoOverlayView;
            _raceInfoOverlayController = MVCFactory.CreateController<GameplayRaceInfoOverlayController, GameplayRaceInfoOverlayModel, GameplayRaceInfoOverlayModelData, GameplayRaceInfoOverlayView>(model, view);
        }

        #endregion

        #region DeInitialize: InnerMVCs

        private void DeInitializeInnerMVCs()
        {
            DeInitializeRaceMVC();
            DeInitializeCarUIMVC();
            DeInitializeRaceInfoOverlayMVC();
        }

        #endregion


        #region DeInitialize: InnerMVCs: Race

        private void DeInitializeRaceMVC()
        {
            _raceController.DeInit();
        }

        #endregion

        #region DeInitialize: InnerMVCs: CarUI

        private void DeInitializeCarUIMVC()
        {
            _carUIController.DeInit();
        }

        #endregion

        #region DeInitialize: InnerMVCs: RaceInfoOverlay

        private void DeInitializeRaceInfoOverlayMVC()
        {
            _raceInfoOverlayController.DeInit();
        }

        #endregion



        #endregion


        #region Show | Hide: InnerMVCs

        #region Show: InnerMVCs

        private void ShowInnerMVCs()
        {
            _raceController.Show();
            _carUIController.Show();
            _raceInfoOverlayController.Show();
        }

        #endregion


        #region Hide: InnerMVCs

        private void HideInnerMVCs()
        {
            _raceController.Hide();
            _carUIController.Hide();
            _raceInfoOverlayController.Hide();
        }

        #endregion

        #endregion


        #region Events: Add | Remove

        protected override void OnAddEvents()
        {
        }

        protected override void OnRemoveEvents()
        {
        }

        #endregion
    }
}
