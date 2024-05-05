using SuperGearsGames.Demo.Layers;
using SuperGearsGames.Demo.Layers.Data;
using System;

namespace SuperGearsGames.Demo.Initializer
{
    public class DataLayerInitializer : LayerInitializer
    {
        #region Fields

        private DataLayer _dataLayer;

        #endregion

        #region Constructor

        public DataLayerInitializer(ILayerInitializer nextInitializer, InitializerManager initializerManager) : base(nextInitializer, initializerManager, nameof(DataLayerInitializer))
        {
        }

        #endregion


        #region OnInit

        protected override void OnInit()
        {
            _dataLayer = LayerContainer.Instance.Data;

            RemoveEvents();
            AddEvents();

            _dataLayer.Init();
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
            _dataLayer.LayerInitializationCompletedEvent += OnLayerInitializationCompleted;
        }

        private void RemoveEvents()
        {
            _dataLayer.LayerInitializationCompletedEvent -= OnLayerInitializationCompleted;
        }

        #endregion
    }
}