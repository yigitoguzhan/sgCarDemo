using System;

namespace SuperGearsGames.Demo.Layers.Data.Repositories
{
    public abstract class ScriptableConfigDataRepository<TDataCollection> : IScriptableConfigDataRepository where TDataCollection : ScriptableConfigDataRepositoryCollection, new()
    {
        #region Data

        protected TDataCollection _dataCollection;
        public TDataCollection DataCollection => _dataCollection;

        #endregion

        #region Settings

        public string Path { get; }

        #endregion

        #region Constructor

        public ScriptableConfigDataRepository(string path)
        {
            Path = path;
        }

        #endregion


        #region Load

        public void Load()
        {
            _dataCollection = new TDataCollection();

            var isLoadSuccess = LoadDataCollection();

            OnLoadCompleted(isLoadSuccess);
        }

        #endregion

        #region LoadDataCollection -> OnLoadDataCollection

        private bool LoadDataCollection()
        {
            try
            {
                var resultDataCollection = OnLoadDataCollection(Path);

                _dataCollection = resultDataCollection;

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        protected abstract TDataCollection OnLoadDataCollection(string path);

        #endregion

        #region OnLoadCompleted

        protected virtual void OnLoadCompleted(bool isSuccess)
        {
        }

        #endregion
    }
}