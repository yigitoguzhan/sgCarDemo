using SuperGearsGames.Demo.Layers.Data;
using SuperGearsGames.Demo.Layers.Data.Repositories;
using System.Collections.Generic;

namespace SuperGearsGames.Demo.Layers.Application.Managers
{
    public class CarManager : Manager
    {
        #region EventHandlers

        #endregion

        #region Data

        public CarData ActiveCarData => UserDataRepositoryContainer.Instance.Car.GetActiveCarData();
        public CarConfigData ActiveCarConfigData => ScriptableConfigRepositoryContainer.Instance.CarScriptableConfig.GetCarConfigData(UserDataRepositoryContainer.Instance.Car.GetActiveCarData().Id);
        public List<CarData> CarDataList => UserDataRepositoryContainer.Instance.Car.GetCarDataList();
        public List<CarConfigData> CarConfigDataList => ScriptableConfigRepositoryContainer.Instance.CarScriptableConfig.GetCarConfigDataList();

        #endregion

        #region Overrides

        protected override void OnBegin()
        {
            Init();
        }

        protected override void OnEnd()
        {

        }

        protected override void OnRegister()
        {
            AddEvents();
        }

        protected override void OnUnRegister()
        {
            RemoveEvents();
        }

        #endregion

        #region Init

        private void Init()
        {

        }

        #endregion

        #region Car: Unlock

        public void UnlockCar(string carId)
        {
            UserDataRepositoryContainer.Instance.Car.UnlockCar(carId);
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
