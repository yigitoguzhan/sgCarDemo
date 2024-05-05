namespace SuperGearsGames.Demo.Layers
{
    public abstract class SGLayer
    {
        #region Init -> OnInit

        public void Init()
        {
            OnInit();
        }

        protected abstract void OnInit();

        #endregion

        #region DeInit -> OnDeInit

        public void DeInit()
        {
            OnDeInit();
        }

        protected abstract void OnDeInit();

        #endregion
    }
}