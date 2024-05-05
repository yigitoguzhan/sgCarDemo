using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Data.Repositories
{
    public class CarScriptableConfigDataRepository: ScriptableConfigDataRepository<CarScriptableConfigDataRepositoryCollection>
    {
        #region Constructor

        public CarScriptableConfigDataRepository(string path) : base(path)
        {
        }

        #endregion

        #region ConfigData: CarList: Get

        public List<CarConfigData> GetCarConfigDataList()
        {
            return _dataCollection.CarConfigDataList;
        }

        #endregion

        #region ConfigData: CarData: Get

        public CarConfigData GetCarConfigData(string id)
        {
            return _dataCollection.CarConfigDataList.Find(x => x.Id == id);
        }

        #endregion

        #region Override: OnLoadDataCollection

        protected override CarScriptableConfigDataRepositoryCollection OnLoadDataCollection(string path)
        {
            var resultDataCollection = new CarScriptableConfigDataRepositoryCollection();

            resultDataCollection.CarConfigDataList = Resources.LoadAll<CarConfigData>(path).ToList();

            return resultDataCollection;
        }

        #endregion
    }
}