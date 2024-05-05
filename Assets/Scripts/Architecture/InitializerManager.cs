using System;
using UnityEngine;

namespace SuperGearsGames.Demo.Initializer
{
    public class InitializerManager : MonoBehaviour
    {
        #region Singleton Instance

        public static InitializerManager Instance { get; private set; }

        #endregion

        #region EventHandlers

        public event EventHandler InitializerManagerReadyEvent;
        public event EventHandler InitializerReadyEvent;

        #endregion

        #region Initializers

        private ILayerInitializer _dataLayerInitializer;
        private ILayerInitializer _applicationLayerInitializer;
        private ILayerInitializer _presentationLayerInitializer;

        #endregion


        #region Unity

        #region Unity: Awake

        private void Awake()
        {
            #region DontDestroyOnLoad

            var objectList = FindObjectsOfType(typeof(InitializerManager));
            if (objectList.Length > 1)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            #endregion

            CreateLayerInitializers();
            StartInitPhase();
        }

        #endregion

        #endregion

        #region LayerInitializers: Create

        private void CreateLayerInitializers()
        {
            _presentationLayerInitializer = new PresentationLayerInitializer(null, this);
            _applicationLayerInitializer = new ApplicationLayerInitializer(_presentationLayerInitializer, this);
            _dataLayerInitializer = new DataLayerInitializer(_applicationLayerInitializer, this);
        }

        #endregion

        #region InitPhase: Start

        public void StartInitPhase()
        {
            _dataLayerInitializer.Init();
        }

        #endregion

        #region InitPhase: Complete

        private void CompleteInitPhase()
        {
            InitializerManagerReadyEvent?.Invoke(this, EventArgs.Empty);
        }

        #endregion


        #region Event: OnLayerInitializerReady

        public void OnLayerInitializerReady(ILayerInitializer layerInitializer)
        {
            Debug.Log($"LayerInitializer: {layerInitializer.Name}");
            InitializerReadyEvent?.Invoke(this, EventArgs.Empty);

            if (layerInitializer == _presentationLayerInitializer)
            {
                CompleteInitPhase();
            }
        }
        
        #endregion
    }
}
