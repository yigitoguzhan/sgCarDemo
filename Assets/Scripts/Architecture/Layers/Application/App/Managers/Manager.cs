using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Application.Managers
{
    public abstract class Manager
    {
        #region Begin -> OnBegin

        public void Begin()
        {
            OnBegin();
        }

        protected abstract void OnBegin();

        #endregion

        #region Register -> OnRegister

        public void Register()
        {
            OnRegister();
        }

        protected abstract void OnRegister();

        #endregion

        #region UnRegister -> OnUnRegister

        public void UnRegister()
        {
            OnUnRegister();
        }

        protected abstract void OnUnRegister();

        #endregion

        #region End -> OnEnd

        public void End()
        {
            OnEnd();
        }

        protected abstract void OnEnd();

        #endregion
    }
    public abstract class ManagerBehaviour : MonoBehaviour
    {
        #region Begin -> OnBegin

        public void Begin()
        {
            OnBegin();
        }

        protected abstract void OnBegin();

        #endregion

        #region Register -> OnRegister

        public void Register()
        {
            OnRegister();
        }

        protected abstract void OnRegister();

        #endregion

        #region UnRegister -> OnUnRegister

        public void UnRegister()
        {
            OnUnRegister();
        }

        protected abstract void OnUnRegister();

        #endregion

        #region End -> OnEnd

        public void End()
        {
            OnEnd();
        }

        protected abstract void OnEnd();

        #endregion
    }

    public abstract class ManagerContainer : MonoBehaviour 
    {
        #region Init -> OnInit

        public void Init()
        {
            OnInit();
        }

        protected abstract void OnInit();

        #endregion

        #region DeInit -> OnDeInit

        public void DeInit()
        {
            OnDeInit();
        }

        protected abstract void OnDeInit();

        #endregion
    }
}
