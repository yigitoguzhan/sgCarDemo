using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SuperGearsGames.Demo.Common
{
    public class SceneController : MonoBehaviour
    {
        #region Singleton Instance

        public static SceneController Instance { get; private set; }

        #endregion

        #region EventHandlers

        public event EventHandler<SceneChangedEventArgs> SceneChangedEvent;

        #endregion

        #region Properties

        public string CurrentScene { get; private set; } = SceneName.Init;


        #endregion


        #region Unity

        #region Unity: Awake

        private void Awake()
        {
            #region DontDestroyOnLoad

            var objectList = FindObjectsOfType(typeof(SceneController));
            if (objectList.Length > 1)
            {
                Destroy(gameObject);
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);

            #endregion

            AddEvents();
        }

        #endregion

        #region Unity: OnDestroy

        private void OnDestroy()
        {
            RemoveEvents();
        }

        #endregion

        #endregion


        #region Scene: Change

        public void ChangeScene(string scene)
        {
            CurrentScene = scene;
            SceneManager.LoadScene(CurrentScene);
        }

        #endregion


        #region Event: OnActiveSceneChanged

        private void OnActiveSceneChanged(Scene arg0, Scene arg1)
        {
            SceneChangedEvent?.Invoke(this, new SceneChangedEventArgs
            {
                PreviousSceneName = arg0.name,
                CurrentSceneName = arg1.name
            });
        }

        #endregion

        #region Events: Add | Remove

        private void AddEvents()
        {
            SceneManager.activeSceneChanged += OnActiveSceneChanged;
        }

        private void RemoveEvents()
        {
            SceneManager.activeSceneChanged -= OnActiveSceneChanged;
        }

        #endregion
    }
}
