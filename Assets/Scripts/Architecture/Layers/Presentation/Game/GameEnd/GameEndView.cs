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

        private void OnBtnGarageClicked()
        {
            AppManagerContainer.Instance.Race.EndCurrentRace();
        }

        #region Events: Add | Remove

        protected override void OnAddEvents()
        {
            _btnGarage.onClick.AddListener(OnBtnGarageClicked);

        }

        protected override void OnRemoveEvents()
        {
            _btnGarage.onClick.RemoveListener(OnBtnGarageClicked);
        }

        #endregion
    }
}
