using SuperGearsGames.Demo.Layers.Application.Managers;

namespace SuperGearsGames.Demo.Layers.Application.Game.Managers
{
    public class GameEndManager : Manager
    {
        #region EventHandlers

        #endregion

        public GameEndManager(GameEndData gameEndData)
        {
            GameEndData = gameEndData;
        }

        #region Data

        public GameEndData GameEndData { get; private set; }

        #endregion

        #region Override

        #region Override: OnBegin

        protected override void OnBegin()
        {
        }

        #endregion

        #region Override: OnRegister

        protected override void OnRegister()
        {
            AddEvents();
        }

        #endregion

        #region Override: OnUnRegister

        protected override void OnUnRegister()
        {
            RemoveEvents();
        }

        #endregion

        #region Override: OnEnd

        protected override void OnEnd()
        {
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
