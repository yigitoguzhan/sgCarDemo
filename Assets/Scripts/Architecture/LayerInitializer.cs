namespace SuperGearsGames.Demo.Initializer
{
    public abstract class LayerInitializer : ILayerInitializer
    {
        public string Name { get ; set ; }
        private readonly ILayerInitializer _nextInitializer;
        private readonly InitializerManager _initializerManager;


        #region Constructor

        protected LayerInitializer(ILayerInitializer nextInitializer, InitializerManager initializerManager, string name)
        {
            _nextInitializer = nextInitializer;
            _initializerManager = initializerManager;
            Name = name;
        }

        #endregion

        #region Init -> OnInit

        public void Init()
        {
            OnInit();
        }

        protected abstract void OnInit();

        #endregion

        #region Init -> Next

        protected void InitNext()
        {
            OnReady();

            _nextInitializer?.Init();
        }

        #endregion


        #region OnReady

        private void OnReady()
        {
            _initializerManager.OnLayerInitializerReady(this);
        }

        #endregion
    }
}
