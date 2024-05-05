using System.Collections.Generic;

namespace SuperGearsGames.Demo.Layers.Data.Repositories
{
    public class CarScriptableConfigDataRepositoryCollection : ScriptableConfigDataRepositoryCollection
    {
        public List<CarConfigData> CarConfigDataList { get; set; }
    }
}