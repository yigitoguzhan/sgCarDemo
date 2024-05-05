using SuperGearsGames.Demo.Layers.Application.Managers;
using SuperGearsGames.Demo.Layers.Presentation;

namespace SuperGearsGames.Demo.Layers.Application.Game.Managers
{
    public class GameplayManager : Manager
    {
        #region Constructor

        public GameplayManager(GameplayData gameplayData)
        {
            GameplayData = gameplayData;
        }

        #endregion

        #region Data

        public GameplayData GameplayData { get; private set; }

        #endregion

        #region Modules

        public GameplayCarModule CarModule { get; private set; }


        #endregion


        #region Override

        #region Override: OnBegin

        protected override void OnBegin()
        {
            CreateModules();
            BeginModules();
            RegisterModules();
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
            UnRegisterModules();
            EndModules();
        }

        #endregion

        #endregion

        #region Module: Create | Begin | Register | UnRegister | End

        #region Module: Create

        private void CreateModules()
        {
            CarModule = new GameplayCarModule(GameplayData);
        }

        #endregion

        #region Module: Begin

        private void BeginModules()
        {
            CarModule.Begin();
        }

        #endregion

        #region Module: Register

        private void RegisterModules()
        {
            CarModule.Register();
        }

        #endregion

        #region Module: UnRegister

        private void UnRegisterModules()
        {
            CarModule.UnRegister();
        }

        #endregion

        #region Module: End

        private void EndModules()
        {
            CarModule.End();
        }

        #endregion

        #endregion


        #region Activate: GameplayState

        #region Activate: State: Countdown

        public void ActivateCountdownState()
        {
            GameplayData.StateData.ChangeState(GameplayState.Countdown);
        }

        #endregion

        #region Activate: State: InProgress

        public void ActivateInProgressState()
        {
            GameplayData.StateData.ChangeState(GameplayState.InProgress);
        }

        #endregion

        #region Activate: State: Finished

        public void ActivateFinishedState()
        {
            GameplayData.StateData.ChangeState(GameplayState.Finished);
        }

        #endregion

        #endregion


        #region Event: OnGameplaySceneBecameVisible

        private void OnGameplaySceneBecameVisible(object sender, System.EventArgs e)
        {
            ActivateCountdownState();
        }

        #endregion


        #region Events: Add | Remove

        private void AddEvents()
        {
            TransitionUI.Instance.FinishTransitionEvent += OnGameplaySceneBecameVisible;
        }
        private void RemoveEvents()
        {
            TransitionUI.Instance.FinishTransitionEvent -= OnGameplaySceneBecameVisible;
        }

        #endregion

    }
}
