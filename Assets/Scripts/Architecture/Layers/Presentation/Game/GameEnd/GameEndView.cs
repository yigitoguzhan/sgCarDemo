using SuperGearsGames.Demo.Layers.Application.Managers;
using UnityEngine;
using UnityEngine.UI;

namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    public class GameEndView : View<GameEndModel, GameEndModelData>
    {
        #region EventHandler


        #endregion

        #region Fields

        [SerializeField]
        private Button _btnGarage;
        [SerializeField]
        private Button _btnRestart;

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
        }

        #endregion


        #region Event: OnBtnGarageClicked

        private void OnBtnGarageClicked()
        {
            AppManagerContainer.Instance.Race.EndCurrentRace();
        }

        #endregion

        #region Event: OnBtnRestartClicked

        private void OnBtnRestartClicked()
        {
            AppManagerContainer.Instance.Race.RestartCurrentRace();
        }

        #endregion

        #region Events: Add | Remove

        protected override void OnAddEvents()
        {
            _btnGarage.onClick.AddListener(OnBtnGarageClicked);
            _btnRestart.onClick.AddListener(OnBtnRestartClicked);
        }

        protected override void OnRemoveEvents()
        {
            _btnGarage.onClick.RemoveListener(OnBtnGarageClicked);
            _btnRestart.onClick.RemoveListener(OnBtnRestartClicked);
        }

        #endregion
    }
}
