using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    public class GameplayCarController : Controller<GameplayCarModel,GameplayCarModelData,GameplayCarView>
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


        #region Get: CarPosition

        public Vector3 GetCarPosition()
        {
            return _view.transform.position;
        }

        #endregion


        #region Event: OnRaceStarted

        public void OnRaceStarted()
        {
            //_view.OnRaceStarted();
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
