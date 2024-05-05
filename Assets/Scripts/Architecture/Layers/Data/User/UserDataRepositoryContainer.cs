using System.Collections.Generic;

namespace SuperGearsGames.Demo.Layers.Data.Repositories
{
    public class UserDataRepositoryContainer
    {
        #region Singleton Instance

        public static UserDataRepositoryContainer Instance { get; } = new UserDataRepositoryContainer();

        #endregion

        #region Repositories

        public List<IUserDataRepository> UserDataRepositoryList { get; private set; }

        public CarUserDataRepository Car { get; private set; }

        #endregion

        #region Init | DeInit

        public void Init()
        {
            CreateRepositories();
        }

        public void DeInit()
        {
            SaveRepositories();
        }

        #endregion

        #region Launch

        public void Launch()
        {
            LoadRepositories();
        }

        #endregion


        #region Create: Repositories

        private void CreateRepositories()
        {
            Car = new CarUserDataRepository();

            UserDataRepositoryList = new List<IUserDataRepository>
            {
                Car
            };

        }

        #endregion

        #region Load: Repositories

        private void LoadRepositories()
        {
            foreach (var userDataRepository in UserDataRepositoryList)
            {
                userDataRepository.Load();
            }
        }

        #endregion

        #region Save: Repositories

        private void SaveRepositories()
        {
            foreach (var userDataRepository in UserDataRepositoryList)
            {
                userDataRepository.Save();
            }
        }

        #endregion
    }
}
