using SuperGearsGames.Demo.Layers.Presentation.Common;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    public class GameplayRaceView : View<GameplayRaceModel,GameplayRaceModelData>
    {
        #region EventHandlers

        #endregion

        #region Fields

        private RaceVisual _raceVisual;
        [SerializeField]
        private Transform _transformFinishLine;

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
            InitRaceVisual();
            InitFinishLine();
        }

        #endregion

        #region Init: RaceVisual

        private void InitRaceVisual()
        {
            _raceVisual = Instantiate(_model.RaceData.ConfigData.RaceVisual, transform);
        }

        #endregion

        #region Init: FinishLine

        private void InitFinishLine()
        {
            _transformFinishLine.position = Vector3.forward * _model.RaceData.ConfigData.RaceLength;
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
