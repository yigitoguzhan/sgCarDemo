using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Data.Repositories
{
    public class RaceScriptableConfigDataRepository: ScriptableConfigDataRepository<RaceScriptableConfigDataRepositoryCollection>
    {
        #region Constructor

        public RaceScriptableConfigDataRepository(string path) : base(path)
        {
        }

        #endregion

        #region ConfigData: RaceList: Get

        public List<RaceConfigData> GetRaceConfigDataList()
        {
            return _dataCollection.RaceConfigDataList;
        }

        #endregion

        #region ConfigData: RaceData: Get

        public RaceConfigData GetRaceConfigData(string id)
        {
            return _dataCollection.RaceConfigDataList.Find(x => x.Id == id);
        }

        #endregion

        #region Override: OnLoadDataCollection

        protected override RaceScriptableConfigDataRepositoryCollection OnLoadDataCollection(string path)
        {
            var resultDataCollection = new RaceScriptableConfigDataRepositoryCollection();

            resultDataCollection.RaceConfigDataList = Resources.LoadAll<RaceConfigData>(path).ToList();

            return resultDataCollection;
        }

        #endregion
    }
}