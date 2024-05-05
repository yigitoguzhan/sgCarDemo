using SuperGearsGames.Demo.Layers.Data.Repositories;
using System;

namespace SuperGearsGames.Demo.Layers.Data
{
    public class DataLayer : SGLayer
    {
        #region EventHandlers

        public event EventHandler LayerInitializationCompletedEvent;

        #endregion

        #region Override: OnInit

        protected override void OnInit()
        {
            InitScriptableConfigRepositoryContainer();
            InitUserDataRepositoryContainer();
            LayerInitializationCompletedEvent?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Override: OnDeInit

        protected override void OnDeInit()
        {
            UserDataRepositoryContainer.Instance.DeInit();
            ScriptableConfigRepositoryContainer.Instance.DeInit();
        }

        #endregion


        #region Init: ScriptableConfigRepositoryContainer

        private void InitScriptableConfigRepositoryContainer()
        {
            ScriptableConfigRepositoryContainer.Instance.Init();
            ScriptableConfigRepositoryContainer.Instance.Launch();
        }

        #endregion

        #region Init: UserDataRepositoryContainer

        private void InitUserDataRepositoryContainer()
        {
            UserDataRepositoryContainer.Instance.Init();
            UserDataRepositoryContainer.Instance.Launch();
        }

        #endregion
    }
}