using SuperGearsGames.Demo.Layers.Application.Game;
using SuperGearsGames.Demo.Layers.Application.Game.Managers;
using SuperGearsGames.Demo.Layers.Presentation.Common;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    public class GameplayCarView : View<GameplayCarModel, GameplayCarModelData>
    {
        #region EventHandlers

        #endregion

        #region Fields

        private CarVisual _carVisual;

        [SerializeField]
        private Transform _transformFollowCamera;

        private Vector3 _lastMousePosition;

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
            UpdateCarPosition();
            UpdateCarSound();
            UpdateBrakeLights();
            UpdateWheelRotation();
            UpdateCamera();
        }

        #region Init

        private void Init()
        {
            InitCarVisual();
        }

        #endregion

        #region Init: CarVisual

        private void InitCarVisual()
        {
            _carVisual = Instantiate(_model.CarData.ConfigData.CarVisual, transform);
        }

        #endregion

        #region Update: CarPosition

        private void UpdateCarPosition()
        {
            transform.localPosition = _model.Data.CarData.Position;
        }

        #endregion

        #region Update: WheelRotation

        private void UpdateWheelRotation()
        {
            _carVisual.BackWheels.rotation = Quaternion.Euler(Vector3.right * _model.CarData.WheelAngle * 180f);
            _carVisual.FrontWheels.rotation = Quaternion.Euler(Vector3.right * _model.CarData.WheelAngle * 180f);
        }

        #endregion

        #region Update: CarSound

        private void UpdateCarSound()
        {
            _carVisual.RunningSound.pitch = _model.CarData.Pitch;
        }

        #endregion

        #region Update: BrakeLights

        private void UpdateBrakeLights()
        {
            _carVisual.BrakeLights.SetActive(_model.CarData.BrakePedalState == Application.Game.BrakePedalState.Pressed);
        }

        #endregion

        #region Update: Camera

        private void UpdateCamera()
        {
            if (Input.GetMouseButtonDown(0))
            {
                _lastMousePosition = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                Vector3 currentMousePosition = Input.mousePosition;
                float deltaX = currentMousePosition.x - _lastMousePosition.x;

                float rotationAngle = deltaX * 0.1f; 
                Vector3 rotationVector = new Vector3(0, rotationAngle, 0);

                _transformFollowCamera.Rotate(rotationVector, Space.World);

                _lastMousePosition = currentMousePosition;
            }
        }

        #endregion

        #region Event: OnGameplayStateChanged

        private void OnGameplayStateChanged(object sender, GameplayStateChangedEventArgs e)
        {
            if(e.State == GameplayState.Countdown)
            {
                _carVisual.RunningSound.Play(); 
            }
        }

        #endregion


        #region Events: Add | Remove

        protected override void OnAddEvents()
        {
            GameManagerContainer.Instance.Game.Gameplay.GameplayData.StateData.GameplayStateChangedEvent += OnGameplayStateChanged;
        }
        protected override void OnRemoveEvents()
        {
             GameManagerContainer.Instance.Game.Gameplay.GameplayData.StateData.GameplayStateChangedEvent -= OnGameplayStateChanged;
        }

        #endregion
    }
}
