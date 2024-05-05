using SuperGearsGames.Demo.Layers.Application.Managers;

namespace SuperGearsGames.Demo.Layers.Presentation.Lobby
{
    public class LobbyUIController : Controller<LobbyUIModel, LobbyUIModelData, LobbyUIView>
    {
        #region Controllers

        #endregion

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


        #region Event: OnStartRaceRequested

        private void OnStartRaceRequested(object sender, System.EventArgs e)
        {
            AppManagerContainer.Instance.Race.InitiateRace();
        } 

        #endregion

        #region Events: Add | Remove

        protected override void OnAddEvents()
        {
            _view.PlayBtnClickedEvent += OnStartRaceRequested;
        }

        protected override void OnRemoveEvents()
        {
            _view.PlayBtnClickedEvent -= OnStartRaceRequested;
        }

        #endregion
    }
}
