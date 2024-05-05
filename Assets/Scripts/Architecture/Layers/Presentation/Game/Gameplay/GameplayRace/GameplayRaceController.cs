namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    public class GameplayRaceController : Controller<GameplayRaceModel,GameplayRaceModelData, GameplayRaceView>
    {
        #region EventHandlers

        #endregion

        #region Controllers

        private GameplayCarController _carController;

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
            InitializeGameplayCarMVC();
        }

        #endregion

        #region Initialize: InnerMVCs: Car

        private void InitializeGameplayCarMVC()
        {
            var modelData = new GameplayCarModelData(_model.RaceData.CarData);
            var model = MVCFactory.CreateModel<GameplayCarModel, GameplayCarModelData>(modelData);
            var view = MVCFactory.CreateView<GameplayCarView>(PresentationConfig.GAMEPLAY_CAR_VIEW_PATH,_view.transform);
            _carController = MVCFactory.CreateController<GameplayCarController, GameplayCarModel, GameplayCarModelData, GameplayCarView>(model, view);
        }

        #endregion


        #region DeInitialize: InnerMVCs

        private void DeInitializeInnerMVCs()
        {
            DeInitializeGameplayCarMVC();
        }

        #endregion

        #region DeInitialize: InnerMVCs: Car

        private void DeInitializeGameplayCarMVC()
        {
            _carController.DeInit();
        }

        #endregion

        #endregion


        #region Show | Hide: InnerMVCs

        #region Show: InnerMVCs

        private void ShowInnerMVCs()
        {
            _carController.Show();
        }

        #endregion


        #region Hide: InnerMVCs

        private void HideInnerMVCs()
        {
            _carController.Hide();
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
