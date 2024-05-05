using UnityEngine;


namespace SuperGearsGames.Demo.Layers.Presentation
{
    public class InitSceneInitializer : MonoBehaviour, ISceneInitializer
    {
        #region Unity

        #region Unity: Awake

        private void Awake()
        {
            #region DontDestroyOnLoad

            var objectList = FindObjectsOfType(typeof(InitSceneInitializer));
            if (objectList.Length > 1)
            {
                Destroy(gameObject);
            }

            //DontDestroyOnLoad(gameObject);

            #endregion

            Initialize();
        }

        #endregion

        #endregion

        #region Show | Hide

        private void Show()
        {
            gameObject.SetActive(true);
        }

        private void Hide()
        {
            gameObject.SetActive(false);
        } 

        #endregion

        #region Initialize

        public void Initialize()
        {
            AddEvents();
            Show();
        }

        #endregion


        #region DeInitialize

        public void DeInitialize()
        {
            Hide();
            RemoveEvents();
        }

        #endregion


        #region Events: Add | Remove

        private void AddEvents()
        {
        }

        private void RemoveEvents()
        {
        }

        #endregion
    }
}
