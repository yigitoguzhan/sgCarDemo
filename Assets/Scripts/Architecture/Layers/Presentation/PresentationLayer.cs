using SuperGearsGames.Demo.Common;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Presentation
{
    public class PresentationLayer : SGLayer
    {
        #region EventHandlers

        public event EventHandler LayerInitializationCompletedEvent;
        public event EventHandler PresentationStateChangeStartedEvent;
        public event EventHandler<PresentationStateChangeCompletedEventArgs> PresentationStateChangeCompletedEvent;

        #endregion

        #region Data

        private Dictionary<string, ISceneInitializer> _sceneInitializers;

        private string _previousSceneName = string.Empty;
        private string _currentSceneName = string.Empty;

        #endregion


        #region Override: OnInit

        protected override void OnInit()
        {
            AddEvents();
            ChangePresentationState(SceneName.Lobby);

            LayerInitializationCompletedEvent?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Override: OnDeInit

        protected override void OnDeInit()
        {
            RemoveEvents();
        }

        #endregion


        #region SceneInitializer: Set

        public void SetSceneInitializer(Dictionary<string, ISceneInitializer> sceneInitializers)
        {
            _sceneInitializers = sceneInitializers;
        }

        #endregion

        #region SceneInitializer: Init

        private void InitSceneInitializer(string sceneName)
        {
            var tryGetSceneInitializerResult = _sceneInitializers.TryGetValue(sceneName, out var sceneInitializer);
            if (!tryGetSceneInitializerResult)
            {
                return;
            }

            sceneInitializer.Initialize();
        }

        #endregion

        #region SceneInitializer: DeInit

        public void DeInitSceneInitializer(string sceneName)
        {
            var tryGetSceneInitializerResult = _sceneInitializers.TryGetValue(sceneName, out var sceneInitializer);
            if (!tryGetSceneInitializerResult)
            {
                return;
            }

            sceneInitializer.DeInitialize();
        }

        #endregion

        #region Change: PresentationState: Routine

        private IEnumerator ChangePresentationStateRoutine(string sceneName)
        {
            yield return new WaitForSeconds(1f);

            InitSceneInitializer(sceneName);
        }

        #endregion

        #region Change: PresentationState

        public void ChangePresentationState(string sceneName)
        {
            PresentationStateChangeStartedEvent?.Invoke(this, EventArgs.Empty);

            _previousSceneName = SceneController.Instance.CurrentScene;
            _currentSceneName = sceneName;

            DeInitSceneInitializer(_previousSceneName);

            SceneController.Instance.ChangeScene(_currentSceneName);
        }

        #endregion


        #region Event: OnSceneChanged

        private void OnSceneChanged(object sender, SceneChangedEventArgs e)
        {
            LayerContainer.Instance.StartCoroutine(ChangePresentationStateRoutine(e.CurrentSceneName));

            PresentationStateChangeCompletedEvent?.Invoke(this, new PresentationStateChangeCompletedEventArgs(_previousSceneName, _currentSceneName));

            _currentSceneName = string.Empty;
            _previousSceneName = string.Empty;
        }

        #endregion

        #region Events: Add | Remove

        private void AddEvents()
        {
            SceneController.Instance.SceneChangedEvent += OnSceneChanged;
        }

        private void RemoveEvents()
        {
            SceneController.Instance.SceneChangedEvent -= OnSceneChanged;
        }

        #endregion
    }
}