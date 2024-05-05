using SuperGearsGames.Demo.Layers.Application.Game;
using SuperGearsGames.Demo.Layers.Application.Game.Managers;

namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    public class GameplayCarUIController : Controller<GameplayCarUIModel,GameplayCarUIModelData,GameplayCarUIView>
    {
        #region Override

        #region Override: OnInit

        protected override void OnInit()
        {
        }

        #endregion

        #region Override: OnDeInit

        protected override void OnDeInit()
        {
        }

        #endregion

        #region Override: OnShow

        protected override void OnShow()
        {
        }

        #endregion

        #region Override: OnHide

        protected override void OnHide()
        {
        }

        #endregion

        #endregion

        private void OnBrakePressed(object sender, System.EventArgs e)
        {
            _model.CarData.SetBrakePedal(BrakePedalState.Pressed);
        }
        private void OnBrakeReleased(object sender, System.EventArgs e)
        {
            _model.CarData.SetBrakePedal(BrakePedalState.Released);

        }
        private void OnGasPressed(object sender, System.EventArgs e)
        {
            _model.CarData.SetGasPedal(GasPedalState.Pressed);

        }
        private void OnGasReleased(object sender, System.EventArgs e)
        {
            _model.CarData.SetGasPedal(GasPedalState.Released);
        }

        #region Events: Add | Remove

        protected override void OnAddEvents()
        {
            _view.BtnBrakePressedEvent += OnBrakePressed;
            _view.BtnBrakeReleasedEvent += OnBrakeReleased;
            _view.BtnGasPressedEvent += OnGasPressed;
            _view.BtnGasReleasedEvent += OnGasReleased;

        }


        protected override void OnRemoveEvents()
        {
        }

        #endregion
    }
}
