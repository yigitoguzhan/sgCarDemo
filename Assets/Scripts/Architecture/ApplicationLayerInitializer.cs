using SuperGearsGames.Demo.Layers.Application;
using SuperGearsGames.Demo.Layers;
using System;

namespace SuperGearsGames.Demo.Initializer
{
    public class ApplicationLayerInitializer : LayerInitializer
    {
        #region Fields

        private ApplicationLayer _applicationLayer;

        #endregion

        #region Constructor

        public ApplicationLayerInitializer(ILayerInitializer nextInitializer, InitializerManager initializerManager) : base(nextInitializer, initializerManager, nameof(ApplicationLayerInitializer))
        {
        }

        #endregion

        #region OnInit

        protected override void OnInit()
        {
            _applicationLayer = LayerContainer.Instance.Application;

            RemoveEvents();
            AddEvents();

            _applicationLayer.Init();
        }

        #endregion


        #region Ready

        private void Ready()
        {
            RemoveEvents();

            InitNext();
        }

        #endregion


        #region Event: OnLayerInitializationCompleted

        private void OnLayerInitializationCompleted(object sender, EventArgs e)
        {
            Ready();
        }

        #endregion


        #region Events: Add | Remove

        private void AddEvents()
        {
            _applicationLayer.LayerInitializationCompletedEvent += OnLayerInitializationCompleted;
        }

        private void RemoveEvents()
        {
            _applicationLayer.LayerInitializationCompletedEvent -= OnLayerInitializationCompleted;
        }

        #endregion
    }
}