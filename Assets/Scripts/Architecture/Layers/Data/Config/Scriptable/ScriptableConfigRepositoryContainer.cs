using System.Collections.Generic;

namespace SuperGearsGames.Demo.Layers.Data.Repositories
{
    public class ScriptableConfigRepositoryContainer
    {
        #region Singleton Instance

        public static ScriptableConfigRepositoryContainer Instance { get; } = new ScriptableConfigRepositoryContainer();

        #endregion

        #region Repositories

        private List<IScriptableConfigDataRepository> _dataRepositories;

        public CarScriptableConfigDataRepository CarScriptableConfig { get; private set; }
        public RaceScriptableConfigDataRepository RaceScriptableConfig { get; private set; }

        #endregion

        #region Init | DeInit

        public void Init()
        {
            CreateRepositories();
        }

        public void DeInit()
        {
            CarScriptableConfig = null;
            RaceScriptableConfig = null;
        }

        #endregion

        #region Launch

        public void Launch()
        {
            LoadRepositories();
        }

        #endregion


        #region Repositories: Create

        private void CreateRepositories()
        {
            _dataRepositories = new List<IScriptableConfigDataRepository>();

            CarScriptableConfig = new CarScriptableConfigDataRepository(ScriptableConfigRepositoryPath.ConfigPath + ScriptableConfigRepositoryName.Car);
            RaceScriptableConfig = new RaceScriptableConfigDataRepository(ScriptableConfigRepositoryPath.ConfigPath + ScriptableConfigRepositoryName.Race);

            _dataRepositories.Add(CarScriptableConfig);
            _dataRepositories.Add(RaceScriptableConfig);
        }

        #endregion

        #region Repositories: Load

        private void LoadRepositories()
        {
            foreach (var repository in _dataRepositories)
            {
                LoadRepository(repository);
            }
        }

        private void LoadRepository(IScriptableConfigDataRepository repository)
        {
            repository.Load();
        }

        #endregion
    }
}