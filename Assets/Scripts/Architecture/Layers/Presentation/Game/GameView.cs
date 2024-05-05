using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    public class GameView : View<GameModel, GameModelData>
    {
        #region EventHandlers

        #endregion

        #region Fields
        [SerializeField]
        private GameplayView _gameplayView;
        public GameplayView GameplayView => _gameplayView;

        [SerializeField]
        private GameEndView _gameEndView;
        public GameEndView GameEndView => _gameEndView;

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