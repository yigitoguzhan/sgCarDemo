using SuperGearsGames.Demo.Layers.Presentation.Common;
using System;
using TMPro;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    public class GameplayCarUIView : View<GameplayCarUIModel, GameplayCarUIModelData>
    {
        #region EventHandlers

        public event EventHandler BtnBrakePressedEvent;
        public event EventHandler BtnBrakeReleasedEvent;

        public event EventHandler BtnGasPressedEvent;
        public event EventHandler BtnGasReleasedEvent;

        #endregion

        #region Fields

        [Header("SpeedMeter")]
        [SerializeField]
        private TextMeshProUGUI _txtGearInfo;
        [SerializeField]
        private TextMeshProUGUI _txtSpeedInfo;
        [SerializeField]
        private Transform _transformPointer;

        [Header("Buttons")]
        [SerializeField]
        private GameInputButton _btnGas;

        [SerializeField]
        private GameInputButton _btnBrake;

        [SerializeField] private float _pointerMinAngle;
        [SerializeField] private float _pointerMaxAngle;
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


        #region Unity: Update

        private void Update()
        {
            UpdatePointer();
            UpdateSpeedInfo();
            UpdateGearInfo();
        }

        #endregion

        #region Update: Pointer

        private void UpdatePointer()
        {
            var normalizedRPMByGearMaxSpeed = _model.CarData.Speed / _model.CarData.ConfigData.EngineConfigData.GearConfigData.MaxGearSpeedArray[_model.CarData.CurrentGear - 1];
            var pointerAngle = _pointerMinAngle - (-normalizedRPMByGearMaxSpeed * (_pointerMaxAngle - _pointerMinAngle));

            _transformPointer.rotation = Quaternion.Euler(Vector3.forward * pointerAngle);
        }

        #endregion

        #region Update: SpeedInfo

        private void UpdateSpeedInfo()
        {
            _txtSpeedInfo.text = $"{(int)_model.CarData.Speed}";
        }

        #endregion

        #region Update: GearInfo

        private void UpdateGearInfo()
        {
            _txtGearInfo.text = $"{_model.CarData.CurrentGear}";
        }

        #endregion


        #region Init

        private void Init()
        {
            InitPointer();
        }

        #endregion

        #region Init: Pointer

        private void InitPointer()
        {
            _transformPointer.rotation = Quaternion.Euler(Vector3.forward * _pointerMinAngle);
        }

        #endregion  


        #region Event: OnButtonBrakePressed

        private void OnButtonBrakePressed(object sender, EventArgs e)
        {
            BtnBrakePressedEvent?.Invoke(this, e);
        }

        #endregion

        #region Event: OnButtonBrakeReleased

        private void OnButtonBrakeReleased(object sender, EventArgs e)
        {
            BtnBrakeReleasedEvent?.Invoke(this, e);
        }

        #endregion

        #region Event: OnButtonGasPressed

        private void OnButtonGasPressed(object sender, EventArgs e)
        {
            BtnGasPressedEvent?.Invoke(this, e);
        }

        #endregion

        #region Event: OnButtonGasReleased

        private void OnButtonGasReleased(object sender, EventArgs e)
        {
            BtnGasReleasedEvent?.Invoke(this, e);
        }

        #endregion

        #region Events: Add | Remove

        protected override void OnAddEvents()
        {
            _btnBrake.ButtonPressedEvent += OnButtonBrakePressed;
            _btnBrake.ButtonReleasedEvent += OnButtonBrakeReleased;

            _btnGas.ButtonPressedEvent += OnButtonGasPressed;
            _btnGas.ButtonReleasedEvent += OnButtonGasReleased;
        }


        protected override void OnRemoveEvents()
        {
            _btnBrake.ButtonPressedEvent -= OnButtonBrakePressed;
            _btnBrake.ButtonReleasedEvent -= OnButtonBrakeReleased;

            _btnGas.ButtonPressedEvent -= OnButtonGasPressed;
            _btnGas.ButtonReleasedEvent -= OnButtonGasReleased;
        }

        #endregion
    }
}