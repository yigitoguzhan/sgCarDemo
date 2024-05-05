using SuperGearsGames.Demo.Common;
using SuperGearsGames.Demo.Layers.Application.Game.Managers;
using SuperGearsGames.Demo.Layers.Application.Managers;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    public class GameEndController : Controller<GameEndModel,GameEndModelData,GameEndView>
    {
        #region EventHandlers

        #endregion

        #region Constants

        #endregion

        #region Controller

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
        }

        #endregion


        #region DeInitialize: InnerMVCs

        private void DeInitializeInnerMVCs()
        {
        }

        #endregion

        #endregion


        #region Show | Hide: InnerMVCs

        #region Show: InnerMVCs

        private void ShowInnerMVCs()
        {
        }

        #endregion


        #region Hide: InnerMVCs

        private void HideInnerMVCs()
        {
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
