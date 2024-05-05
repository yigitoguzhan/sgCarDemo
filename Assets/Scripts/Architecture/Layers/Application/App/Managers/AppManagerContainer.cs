using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Application.Managers
{
    public class AppManagerContainer : MonoBehaviour
    {
        #region Singleton Instance

        public static AppManagerContainer Instance { get; private set; }

        #endregion

        #region Managers

        public CarManager Car {  get; private set; }
        public RaceManager Race { get; private set; }

        #endregion


        #region Unity: Awake

        private void Awake()
        {
            #region DontDestroyOnLoad

            var objectList = FindObjectsOfType(typeof(AppManagerContainer));
            if (objectList.Length > 1)
            {
                Destroy(gameObject);
            }

            Instance = this;
            //DontDestroyOnLoad(gameObject);

            #endregion
        }

        #endregion

        #region Init | DeInit

        public void Init()
        {
            CreateManagers();
        }

        public void DeInit()
        {
            UnRegisterManagers();
            EndManagers();
        }

        #endregion

        #region Launch

        public void Launch()
        {
            BeginManagers();
            RegisterManagers();
        }

        #endregion


        #region Managers: Create

        private void CreateManagers()
        {
            Car = new CarManager();
            Race = new RaceManager();
        }

        #endregion

        #region Managers: Begin

        private void BeginManagers()
        {
            Car.Begin();
            Race.Begin();
        }

        #endregion

        #region Managers: Register

        private void RegisterManagers()
        {
            Car.Register();
            Race.Register();
        }

        #endregion

        #region Managers: UnRegister

        private void UnRegisterManagers()
        {
            Car.UnRegister();
            Race.UnRegister();
        }

        #endregion

        #region Managers: End

        private void EndManagers()
        {
            Car.End();
            Race.End();
        }

        #endregion
    }
}