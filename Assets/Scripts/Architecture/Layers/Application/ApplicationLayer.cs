using SuperGearsGames.Demo.Layers.Application.Managers;
using System;

namespace SuperGearsGames.Demo.Layers.Application
{
    public class ApplicationLayer : SGLayer
    {
        #region EventHandlers

        public event EventHandler LayerInitializationCompletedEvent;

        #endregion

        #region Override: OnInit

        protected override void OnInit()
        {
            InitAppManagerContainer();
            LayerInitializationCompletedEvent?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Override: OnDeInit

        protected override void OnDeInit()
        {
            AppManagerContainer.Instance.DeInit();
        }

        #endregion

        #region Init: AppManagerContainer

        private void InitAppManagerContainer()
        {
            AppManagerContainer.Instance.Init();
            AppManagerContainer.Instance.Launch();
        }

        #endregion
    }
}