using SuperGearsGames.Demo.Common;
using System.Collections.Generic;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Presentation
{
    public class SceneInitializerContainer : MonoBehaviour
    {
        #region Singleton Instance

        private static SceneInitializerContainer _instance;
        public static SceneInitializerContainer Instance => _instance;

        #endregion

        #region Fields

        [Header("Scene Initializers")]
        [SerializeField]
        private InitSceneInitializer _initSceneInitializer;

        [SerializeField]
        private LobbySceneInitializer _lobbySceneInitializer;
        
        [SerializeField]
        private GameSceneInitializer _gameSceneInitializer;
        public GameSceneInitializer GameSceneInitializer => _gameSceneInitializer;

        #endregion

        #region Unity: Awake

        private void Awake()
        {
            #region DontDestroyOnLoad

            var objectList = FindObjectsOfType(typeof(SceneInitializerContainer));
            if (objectList.Length > 1)
            {
                Destroy(gameObject);
            }

            _instance = this;
           // DontDestroyOnLoad(gameObject);

            #endregion

            SetSceneInitializers();
        }

        #endregion

        #region Layers: Presentation: SetSceneInitializers

        private void SetSceneInitializers()
        {
            var sceneInitializers = new Dictionary<string, ISceneInitializer>()
            {
                { SceneName.Init, _initSceneInitializer},
                { SceneName.Lobby, _lobbySceneInitializer},
                { SceneName.Game, _gameSceneInitializer}
            };

            LayerContainer.Instance.Presentation.SetSceneInitializer(sceneInitializers);
        }

        #endregion
    }
}