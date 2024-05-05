using SuperGearsGames.Demo.Layers.Application.Managers;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Application.Lobby.Managers
{
    public class LobbyManagerContainer : ManagerContainer
    {
        #region Singleton Instance

        public static LobbyManagerContainer Instance { get; private set; }

        #endregion

        #region Managers

        public LobbyManager Lobby { get; private set; }

        #endregion

        #region Unity: Awake

        private void Awake()
        {
            #region Instance

            var objectList = FindObjectsOfType(typeof(LobbyManagerContainer));
            if (objectList.Length > 1)
            {
                Destroy(gameObject);
            }

            Instance = this;

            #endregion
        }

        #endregion

        #region Overrides: OnInit | OnDeInit

        protected override void OnInit()
        {
            CreateManagers();
        }

        protected override void OnDeInit()
        {
            DestroyManagers();
        }

        #endregion

        #region Launch

        public void Launch()
        {
            BeginManagers();
            RegisterManagers();
        }

        #endregion

        #region End

        public void End()
        {
            UnRegisterManagers();
            EndManagers();
        }

        #endregion

        #region Manager: Create

        private void CreateManagers()
        {
            Lobby = new LobbyManager();
        }

        #endregion

        #region Manager: Begin

        private void BeginManagers()
        {
            Lobby.Begin();
        }

        #endregion

        #region Manager: Register

        private void RegisterManagers()
        {
            Lobby.Register();
        }

        #endregion

        #region Manager: UnRegister

        private void UnRegisterManagers()
        {
            Lobby.UnRegister();
        }

        #endregion

        #region Manager: End

        private void EndManagers()
        {
            Lobby.End();
        }

        #endregion

        #region Manager: Destroy

        private void DestroyManagers()
        {
            Lobby = null;
        }

        #endregion
    }
}


