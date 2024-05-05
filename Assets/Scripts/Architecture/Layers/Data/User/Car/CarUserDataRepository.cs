using System;
using System.Collections.Generic;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Data.Repositories
{
    public class CarUserDataRepository : IUserDataRepository
    {
        #region Constructor

        public CarUserDataRepository()
        {

            CarDataList = new List<CarData>();

        }

        #endregion

        #region Data

        public string CurrentCarId { get; private set; }
        private List<CarData> CarDataList;

        #endregion

        #region Get: CarDataList

        public List<CarData> GetCarDataList()
        {
            return CarDataList;
        }

        #endregion

        #region Get: CarData

        public CarData GetCarData(string id)
        {
            return CarDataList.Find(x => x.Id == id);
        }

        #endregion

        #region Get: ActiveCarData

        public CarData GetActiveCarData()
        {
            return CarDataList.Find(x => x.Id == CurrentCarId);
        }

        #endregion


        #region Car: Unlock

        public void UnlockCar(string id)
        {
            var carData = CarDataList.Find(x => x.Id == id);
            if (carData == null)
            {
                return;
            }

            carData.SetIsOwned(true);
            Save();
        }

        #endregion


        #region UserData: Load

        public void Load()
        {
            var carConfigDataList = ScriptableConfigRepositoryContainer.Instance.CarScriptableConfig.GetCarConfigDataList();
            //Prepare CarDataList
            foreach (var carConfigData in carConfigDataList)
            {
                if (!PlayerPrefs.HasKey("CarOwned " + carConfigData.Id))
                {
                    if (carConfigData.Id == "0")
                    {
                        PlayerPrefs.SetString("CarOwned " + carConfigData.Id, "Owned");
                    }
                    else
                    {
                        PlayerPrefs.SetString("CarOwned " + carConfigData.Id, "notOwned");
                    }
                }

                var isCarOwned = PlayerPrefs.GetString("CarOwned " + carConfigData.Id) == "Owned";
                CarDataList.Add(new CarData(carConfigData.Id, isCarOwned, carConfigData));
            }

            if (!PlayerPrefs.HasKey("CurrentCarId"))
            {
                PlayerPrefs.SetString("CurrentCarId", "0");
            }
            else
            {
                CurrentCarId = PlayerPrefs.GetString("CurrentCarId");
            }
        }

        #endregion

        #region UserData: Save

        public void Save()
        {
            foreach (var carData in CarDataList)
            {
                if (carData.IsOwned)
                {
                    PlayerPrefs.SetString("CarOwned " + carData.Id, "Owned");
                }
            }
            PlayerPrefs.SetString("CurrentCarId", CurrentCarId);
        }

        #endregion
    }
}