using SuperGearsGames.Demo.Layers.Application.Game;
using System;
using System.Collections;
using TMPro;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    public class GameplayRaceInfoOverlayView : View<GameplayRaceInfoOverlayModel, GameplayRaceInfoOverlayModelData>
    {
        #region EventHandlers

        public event EventHandler CountdownTimerTickedEvent;

        #endregion

        #region Fields

        [Header("Text")]
        [SerializeField]
        private TextMeshProUGUI _txtCountDown;

        [Header("Text")]
        [SerializeField]
        private TextMeshProUGUI _txtChronometer;

        #endregion


        #region Override

        #region Override: OnShow

        protected override void OnShow()
        {
            Init();
        }

        #endregion

        #region Override: OnRefresh

        protected override void OnRefresh()
        {
        }

        #endregion

        #region Override: OnHide

        protected override void OnHide()
        {
        }

        #endregion

        #endregion

        private void Update()
        {
            if(_model.GameplayData.StateData.State != GameplayState.InProgress)
            {
                return;
            }
            _model.SetCarTimerValue(_model.CarTimerValue + Time.deltaTime);
            _txtChronometer.text = TimeSpan.FromSeconds(_model.CarTimerValue).ToString(@"mm\:ss\:ff");
        }

        #region Init

        private void Init()
        {
            InitCountdownTimer();
        }

        #endregion

        #region Init: CountdownTimer

        private void InitCountdownTimer()
        {
            _txtCountDown.gameObject.SetActive(_model.GameplayData.StateData.State == GameplayState.Countdown);
            _txtCountDown.text = $"{_model.CountdownTimer}";
        }

        #endregion

        #region Refresh: CountdownTimerRoutine

        IEnumerator RefreshCountdownTimerRoutine()
        {
            yield return new WaitForSeconds(1f);
            while (true)
            {
                if (_model.CountdownTimer - 1 > 0)
                {
                    _txtCountDown.text = $"{_model.CountdownTimer - 1}";
                    _model.SetCountdown(_model.CountdownTimer - 1);
                }
                else
                {
                    _txtCountDown.text = "GO!";
                    _model.GameplayData.StateData.ChangeState(GameplayState.InProgress);
                    break;
                }
                yield return new WaitForSeconds(1f);
            }
            yield return new WaitForSeconds(1f);

            _txtCountDown.gameObject.SetActive(false);
        }

        #endregion


        #region Event: OnGameplayStateChanged

        private void OnGameplayStateChanged(object sender, GameplayStateChangedEventArgs e)
        {
            if (e.State == GameplayState.Countdown)
            {
                _txtCountDown.gameObject.SetActive(true);
                StartCoroutine(RefreshCountdownTimerRoutine());
            }
        }

        #endregion


        #region Events: Add | Remove

        protected override void OnAddEvents()
        {
            _model.GameplayData.StateData.GameplayStateChangedEvent += OnGameplayStateChanged;
        }

        protected override void OnRemoveEvents()
        {
           //_model.GameplayData.StateData.GameplayStateChangedEvent -= OnGameplayStateChanged;
        }

        #endregion
    }
}