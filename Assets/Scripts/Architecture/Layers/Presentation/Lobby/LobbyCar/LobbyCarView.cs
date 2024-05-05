using SuperGearsGames.Demo.Layers.Presentation.Common;

namespace SuperGearsGames.Demo.Layers.Presentation.Lobby
{
    public class LobbyCarView : View<LobbyCarModel, LobbyCarModelData>
    {
        #region EventHandlers

        #endregion

        #region Fields

        private CarVisual _carVisual;

        #endregion

        #region Override

        #region Override: OnShow

        protected override void OnShow()
        {
            Init();
        }

        #endregion

        #region Override: OnRefresh

        protected override void OnRefresh()
        {
        }

        #endregion

        #region Override: OnHide

        protected override void OnHide()
        {
        }

        #endregion

        #endregion


        #region Init

        private void Init()
        {
           InitCarVisual();
        }

        #endregion

        #region Init: CarVisual

        private void InitCarVisual()
        {
            _carVisual = Instantiate(_model.ActiveCarData.Config.CarVisual, transform);
        }

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
