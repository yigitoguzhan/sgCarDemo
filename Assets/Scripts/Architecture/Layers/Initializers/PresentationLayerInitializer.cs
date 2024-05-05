using SuperGearsGames.Demo.Layers;
using SuperGearsGames.Demo.Layers.Presentation;

namespace SuperGearsGames.Demo.Initializer
{
    public class PresentationLayerInitializer : LayerInitializer
    {
        #region Fields

        private PresentationLayer _presentationLayer;

        #endregion

        #region Constructor

        public PresentationLayerInitializer(ILayerInitializer nextInitializer, InitializerManager initializerManager) : base(nextInitializer, initializerManager, nameof(PresentationLayerInitializer))
        {
        }

        #endregion


        #region OnInit

        protected override void OnInit()
        {
            _presentationLayer = LayerContainer.Instance.Presentation;

            RemoveEvents();
            AddEvents();

            _presentationLayer.Init();
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

        private void OnLayerInitializationCompleted(object sender, System.EventArgs e)
        {
            Ready();
        }

        #endregion

        #region Events: Add | Remove

        private void AddEvents()
        {
            _presentationLayer.LayerInitializationCompletedEvent += OnLayerInitializationCompleted;
        }

        private void RemoveEvents()
        {
            _presentationLayer.LayerInitializationCompletedEvent -= OnLayerInitializationCompleted;
        }

        #endregion
    }
}