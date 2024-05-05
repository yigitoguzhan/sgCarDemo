using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    public class GameplayView : View<GameplayModel, GameplayModelData>
    {
        #region EventHandlers

        #endregion

        #region Fields

        [SerializeField]
        private GameplayRaceView _raceView;
        public GameplayRaceView RaceView => _raceView;

        [SerializeField]
        private GameplayCarUIView _carUIView;
        public GameplayCarUIView CarUIView => _carUIView;

        [SerializeField]
        private GameplayRaceInfoOverlayView _raceInfoOverlayView;
        public GameplayRaceInfoOverlayView GameplayRaceInfoOverlayView => _raceInfoOverlayView;

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
