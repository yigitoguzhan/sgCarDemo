using SuperGearsGames.Demo.Layers.Application.Managers;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Application.Game.Managers
{
    public class GameManagerContainer : ManagerContainer
    {
        #region Singleton Instance

        public static GameManagerContainer Instance { get; private set; }

        #endregion

        #region GManagers

        public GameManager Game { get; private set; }

        private bool _isReadyToUpdate = false;

        #endregion


        #region Unity: Awake

        private void Awake()
        {
            #region Instance

            var objectList = FindObjectsOfType(typeof(GameManagerContainer));
            if (objectList.Length > 1)
            {
                Destroy(gameObject);
            }

            Instance = this;

            #endregion
        }

        #endregion

        #region Unity: Update

        private void Update()
        {            
            if (!_isReadyToUpdate)
            {
                return;
            }
            Game.Gameplay.CarModule.ProcessGameplayAction();
        }

        #endregion

        #region Overrides: OnInit | OnDeInit

        protected override void OnInit()
        {
            CreateManagers();
            BeginManagers();
            _isReadyToUpdate = true;
        }

        protected override void OnDeInit()
        {
            DestroyManagers();
        } 

        #endregion


        #region Launch

        public void Launch()
        {
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



        #region Manager: Create | Begin | Register | UnRegister | End

        #region Manager: Create

        private void CreateManagers()
        {
            Game = new GameManager();
        }

        #endregion

        #region Manager: Begin

        private void BeginManagers()
        {
            Game.Begin();
        }

        #endregion

        #region Manager: Register

        private void RegisterManagers()
        {
            Game.Register();
        }

        #endregion

        #region Manager: UnRegister

        private void UnRegisterManagers()
        {
            Game?.UnRegister();
        }

        #endregion

        #region Manager: End

        private void EndManagers()
        {
            Game?.End();
        }

        #endregion

        #region Manager: Destroy

        private void DestroyManagers()
        {
            Game = null;
        }

        #endregion

        #endregion
    }
}