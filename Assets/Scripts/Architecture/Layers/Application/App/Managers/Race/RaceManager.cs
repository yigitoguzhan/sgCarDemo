using SuperGearsGames.Demo.Common;
using SuperGearsGames.Demo.Layers.Data;
using SuperGearsGames.Demo.Layers.Data.Repositories;
using SuperGearsGames.Demo.Layers.Presentation;
using System;

namespace SuperGearsGames.Demo.Layers.Application.Managers
{
    public class RaceManager : Manager
    {
        #region EventHandlers

        public event EventHandler StartRaceRequestedEvent;

        #endregion

        #region Data

        public RaceConfigData CurrentRaceConfigData { get; private set; }

        #endregion

        #region Override

        #region Override: OnBegin

        protected override void OnBegin()
        {
        }

        #endregion

        #region Override: OnEnd

        protected override void OnEnd()
        {
        }

        #endregion

        #region Override: OnRegister

        protected override void OnRegister()
        {
            AddEvents();
        }

        #endregion

        #region Override: OnUnRegister

        protected override void OnUnRegister()
        {
            RemoveEvents();
        }

        #endregion

        #endregion


        #region Race: Initiate

        public void InitiateRace(bool allowStartRace = true)
        {
            //Add RaceUserData if time left, and get the RaceConfigData by ActiveRaceData's Id
            CurrentRaceConfigData = ScriptableConfigRepositoryContainer.Instance.RaceScriptableConfig.GetRaceConfigData("0");

            if (allowStartRace)
            {
                StartRace();
            }
        }

        #endregion

        #region Race: AllowStart

        public bool AllowStartRace()
        {
            if (CurrentRaceConfigData == null)
            {
                return false;
            }
            return true;
        }

        #endregion

        #region Race: Start

        private void StartRace()
        {
            LayerContainer.Instance.Presentation.ChangePresentationState(SceneName.Game);
        }

        #endregion

        #region Race: Current: End

        public void EndCurrentRace()
        {
            LayerContainer.Instance.Presentation.ChangePresentationState(SceneName.Lobby);
        }

        #endregion


        #region Event: OnPresentationStateChangeCompleted

        private void OnPresentationStateChangeCompleted(object sender, PresentationStateChangeCompletedEventArgs e)
        {
            if (e.PreviousSceneName == SceneName.Game)
            {
                CurrentRaceConfigData = null;
            }
        }

        #endregion

        #region Events: Add | Remove

        private void AddEvents()
        {
            LayerContainer.Instance.Presentation.PresentationStateChangeCompletedEvent += OnPresentationStateChangeCompleted;
        }

        private void RemoveEvents()
        {
            LayerContainer.Instance.Presentation.PresentationStateChangeCompletedEvent -= OnPresentationStateChangeCompleted;
        }

        #endregion
    }
}