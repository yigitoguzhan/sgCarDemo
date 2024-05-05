using SuperGearsGames.Demo.Layers.Application;
using SuperGearsGames.Demo.Layers.Data;
using SuperGearsGames.Demo.Layers.Presentation;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers
{
    public class LayerContainer : MonoBehaviour
    {
        #region Singleton Instance

        public static LayerContainer Instance { get; private set; }

        #endregion

        #region Layers

        public DataLayer Data { get; private set; }
        public ApplicationLayer Application { get; private set; }
        public PresentationLayer Presentation { get; private set; }

        #endregion


        #region Unity: Awake

        private void Awake()
        {
            #region DontDestroyOnLoad

            var objectList = FindObjectsOfType(typeof(LayerContainer));
            if (objectList.Length > 1)
            {
                Destroy(gameObject);
            }

            Instance = this;

            DontDestroyOnLoad(gameObject);

            #endregion

            CreateLayers();
        }

        #endregion


        #region Layers: Create

        private void CreateLayers()
        {
            Data = new DataLayer();
            Application = new ApplicationLayer();
            Presentation = new PresentationLayer();
        }

        #endregion
    }
}