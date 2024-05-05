using SuperGearsGames.Demo.Layers.Application.Managers;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Application.Game.Managers
{
    public class GameManager : Manager
    {
        #region Managers

        public GameplayManager Gameplay { get; private set; }
        public GameEndManager GameEnd { get; private set; }

        #endregion

        #region Data

        public GameData GameData { get; private set; }

        #endregion

        #region Override: OnBuild | OnBegin | OnReBegin | OnRegister | OnUnRegister | OnEnd

        protected override void OnBegin()
        {
            CreateData();

            CreateManagers();

            BeginManagers();

        }

        protected override void OnRegister()
        {
            RegisterManagers();

            AddEvents();
        }

        protected override void OnUnRegister()
        {
            UnRegisterManagers();

            RemoveEvents();
        }

        protected override void OnEnd()
        {
            EndManagers();
        }

        #endregion


        #region Data: Create

        private void CreateData()
        {
            var currentRaceConfigData = AppManagerContainer.Instance.Race.CurrentRaceConfigData;
            var currentCarConfigData = AppManagerContainer.Instance.Car.ActiveCarData.Config;
            GameData = GameDataFactory.CreateGameData(currentRaceConfigData,currentCarConfigData);
        }

        #endregion

        #region Manager: Create | Begin | Register | UnRegister | End

        #region Manager: Create

        private void CreateManagers()
        {
            Gameplay = new GameplayManager(GameData.GameplayData);
            GameEnd = new GameEndManager(GameData.GameEndData);
        }

        #endregion

        #region Manager: Begin

        private void BeginManagers()
        {
            Gameplay.Begin();
            GameEnd.Begin();
        }

        #endregion

        #region Manager: Register

        private void RegisterManagers()
        {
            Gameplay.Register();
            GameEnd.Register();
        }

        #endregion

        #region Manager: UnRegister

        private void UnRegisterManagers()
        {
            Gameplay.UnRegister();
            GameEnd.UnRegister();
        }

        #endregion

        #region Manager: End

        private void EndManagers()
        {
            Gameplay.End();
            GameEnd.End();
        }

        #endregion

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
