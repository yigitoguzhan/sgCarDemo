using DG.Tweening;
using SuperGearsGames.Demo.Layers.Application.Managers;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Application.Game.Managers
{
    public class GameplayCarModule : Manager
    {
        #region EventHandler
        #endregion

        #region Constructor

        public GameplayCarModule(GameplayData gameplayData)
        {
            GameplayData = gameplayData;
            CurrentRaceData = gameplayData.CurrentRaceData;
        }

        #endregion

        #region Data

        public GameplayData GameplayData { get; private set; }
        public GameplayRaceData CurrentRaceData { get; private set; }

        #endregion


        #region Override: OnBegin | OnRegister | OnUnRegister | OnEnd

        protected override void OnBegin()
        {
            CreateModules();

            BeginModules();
            RegisterModules();
        }

        protected override void OnRegister()
        {
            AddEvents();
        }

        protected override void OnUnRegister()
        {
            RemoveEvents();
        }

        protected override void OnEnd()
        {
            UnRegisterModules();
            EndModules();
        }

        #endregion

        #region Module: Create | Begin | Register | UnRegister | End

        #region Module: Create

        private void CreateModules()
        {

        }

        #endregion

        #region Module: Begin

        private void BeginModules()
        {
        }

        #endregion


        #region Module: Register

        private void RegisterModules()
        {
        }

        #endregion

        #region Module: UnRegister

        private void UnRegisterModules()
        {
        }

        #endregion

        #region Module: End

        private void EndModules()
        {
        }

        #endregion

        #endregion


        #region Process: GameplayAction

        public void ProcessGameplayAction()
        {
            if (GameplayData.StateData.State != GameplayState.Finished && CurrentRaceData.CarData.GasPedalState == GasPedalState.Pressed)
            {
                OnGasPedalPressed();
            }
            if (GameplayData.StateData.State == GameplayState.Finished || CurrentRaceData.CarData.GasPedalState == GasPedalState.Released)
            {
                OnGasPedalReleased();
            }
            if (CurrentRaceData.CarData.BrakePedalState == BrakePedalState.Pressed)
            {
                OnBrakePedalPressed();
            }
            CalculateCarPosition();
            CalculateWheelAngle();
            CalculatePitch();
        }

        #endregion


        #region Check: Car: Finish

        private void CheckIfCarFinishedTheRace(float carZPos)
        {
            var gameplayCarData = CurrentRaceData.CarData;

            if (carZPos + gameplayCarData.ConfigData.CarForwardPoint >= CurrentRaceData.ConfigData.RaceLength)
            {
                if(GameplayData.StateData.State != GameplayState.Finished)
                {
                    GameManagerContainer.Instance.Game.Gameplay.ActivateFinishedState();
                }
            }
        }

        #endregion


        #region Speed: Increase

        private void IncreaseSpeed()
        {
            var gameplayCarData = CurrentRaceData.CarData;
            var currentGearIndex = gameplayCarData.CurrentGear - 1;
            var currentGearMaxSpeed = gameplayCarData.ConfigData.EngineConfigData.GearConfigData.MaxGearSpeedArray[currentGearIndex];

            gameplayCarData.SetSpeed(gameplayCarData.Speed + gameplayCarData.ConfigData.EngineConfigData.HorsePower * 0.05f * Time.deltaTime);

            var isGearSpeedOnMaxLimit = gameplayCarData.Speed >= currentGearMaxSpeed;
            if (isGearSpeedOnMaxLimit)
            {
                gameplayCarData.SetSpeed(Random.Range(currentGearMaxSpeed - 5f, currentGearMaxSpeed));
            }
        }

        #endregion        

        #region Speed: Decrease: Idle

        private void DecreaseSpeedOnIdle()
        {
            var gameplayCarData = CurrentRaceData.CarData;
            var frictionMultiplier = CurrentRaceData.ConfigData.FrictionMultiplier;

            gameplayCarData.SetSpeed(gameplayCarData.Speed - gameplayCarData.ConfigData.ChasisMass * frictionMultiplier * Time.deltaTime);
        }

        #endregion

        #region Speed: Decrease: Brake

        private void DecreaseSpeedOnBrake()
        {
            var gameplayCarData = CurrentRaceData.CarData;
            var frictionMultiplier = CurrentRaceData.ConfigData.FrictionMultiplier;

            gameplayCarData.SetSpeed(gameplayCarData.Speed - gameplayCarData.ConfigData.ChasisMass * frictionMultiplier * gameplayCarData.ConfigData.BreakForce * Time.deltaTime);

        }

        #endregion


        #region OnPedalPressed : Gas

        private void OnGasPedalPressed()
        {
            var gameplayStateData = GameManagerContainer.Instance.Game.Gameplay.GameplayData.StateData;
            if (gameplayStateData.State == GameplayState.InProgress)
            {
                IncreaseSpeed();
            }


            CheckIfUpShiftNeeded();
        }


        #endregion

        #region OnPedalReleased : Gas

        private void OnGasPedalReleased()
        {
            DecreaseSpeedOnIdle();

            CheckIfDownShiftNeeded();
        }

        #endregion

        #region OnPedalPressed : Brake

        private void OnBrakePedalPressed()
        {
            DecreaseSpeedOnBrake();

            CheckIfDownShiftNeeded();
        }

        #endregion


        #region Check: UpShift

        private void CheckIfUpShiftNeeded()
        {
            var gameplayCarData = CurrentRaceData.CarData;
            var isGearAuto = gameplayCarData.ConfigData.EngineConfigData.GearConfigData.GearType == Data.GearType.Automatic;
            var currentGearIndex = gameplayCarData.CurrentGear - 1;
            var currentGearMaxSpeed = gameplayCarData.ConfigData.EngineConfigData.GearConfigData.MaxGearSpeedArray[currentGearIndex];

            if (gameplayCarData.CurrentGear >= gameplayCarData.ConfigData.EngineConfigData.GearConfigData.MaxGearSpeedArray.Length)
            {
                return;
            }

            if (isGearAuto)
            {
                var currentGearUpShiftMinimumSpeed = currentGearMaxSpeed - currentGearMaxSpeed * gameplayCarData.ConfigData.EngineConfigData.GearConfigData.GearToleranceRate;

                if (gameplayCarData.Speed > currentGearUpShiftMinimumSpeed && gameplayCarData.Speed <= currentGearMaxSpeed)
                {
                    UpShiftGear();
                }
            }
        }

        #endregion

        #region Check: DownShift

        private void CheckIfDownShiftNeeded()
        {
            var gameplayCarData = CurrentRaceData.CarData;
            var currentGearIndex = gameplayCarData.CurrentGear - 1;
            if (currentGearIndex == 0)
            {
                return;
            }

            if (gameplayCarData.Speed < gameplayCarData.ConfigData.EngineConfigData.GearConfigData.MaxGearSpeedArray[currentGearIndex - 1])
            {
                DownShiftGear();
            }

        }

        #endregion


        #region Gear: UpShift

        private void UpShiftGear()
        {
            var gameplayCarData = CurrentRaceData.CarData;
            gameplayCarData.SetGear(gameplayCarData.CurrentGear + 1);

            DecreasePitchOnUpShift();
        }

        #endregion

        #region Gear: DownShift

        private void DownShiftGear()
        {
            var gameplayCarData = CurrentRaceData.CarData;
            gameplayCarData.SetGear(gameplayCarData.CurrentGear - 1);
        }

        #endregion


        #region Calculate: Car: Position

        private void CalculateCarPosition()
        {
            var gameplayCarData = CurrentRaceData.CarData;

            var meterPerSecond = gameplayCarData.Speed * 1000f / 3600f;
            var deltaDistance = meterPerSecond * Time.deltaTime;

            gameplayCarData.SetPosition(gameplayCarData.Position + Vector3.forward * deltaDistance);
            CheckIfCarFinishedTheRace(gameplayCarData.Position.z);
        }

        #endregion

        #region Calculate: Pitch

        private void CalculatePitch()
        {
            var gameplayCarData = CurrentRaceData.CarData;
            var currentGearIndex = gameplayCarData.CurrentGear - 1;
            var currentSpeed = gameplayCarData.Speed;
            var currentGearConfigData = gameplayCarData.ConfigData.EngineConfigData.GearConfigData;
            var maxGearSpeedArray = gameplayCarData.ConfigData.EngineConfigData.GearConfigData.MaxGearSpeedArray;

            if (!gameplayCarData.IsBreathing)
            {
                var normalizedGearSpeed = currentGearIndex == 0 ? (currentSpeed / maxGearSpeedArray[currentGearIndex]) : (currentSpeed - maxGearSpeedArray[currentGearIndex - 1]) / (maxGearSpeedArray[currentGearIndex] - maxGearSpeedArray[currentGearIndex - 1]);
                var pitchValue = Mathf.Lerp(currentGearIndex == 0 ? currentGearConfigData.GearMinPitch : gameplayCarData.GearPitchMaxValues[currentGearIndex - 1], gameplayCarData.GearPitchMaxValues[currentGearIndex], normalizedGearSpeed);
                gameplayCarData.SetPitch(Mathf.MoveTowards(gameplayCarData.Pitch, pitchValue, Time.deltaTime * currentGearConfigData.GearPitchRecoveryRate));
            }
        }

        #endregion

        #region Calculate: WheelAngle

        private void CalculateWheelAngle()
        {
            var currentCarData = CurrentRaceData.CarData;
            var wheelRadius = CurrentRaceData.CarData.ConfigData.WheelRadius;
            var deltaDistance = currentCarData.Speed * 1000f / 3600f * Time.deltaTime;
            var wheelAngle = deltaDistance / (wheelRadius * 2 * Mathf.PI);

            currentCarData.SetWheelAngle(currentCarData.WheelAngle + wheelAngle);
        }

        #endregion


        #region Decrease: Pitch: OnUpShift

        private void DecreasePitchOnUpShift()
        {
            var gameplayCarData = CurrentRaceData.CarData;
            var currentGearIndex = gameplayCarData.CurrentGear - 1;
            var currentGearConfigData = gameplayCarData.ConfigData.EngineConfigData.GearConfigData;
            var gearCount = currentGearConfigData.GearCount;
            gameplayCarData.SetBreath(true);

            var previousGearMaxPitch = currentGearIndex == 0 ? currentGearConfigData.GearMinPitch : gameplayCarData.GearPitchMaxValues[currentGearIndex - 1];
            var currentGearMaxPitch = gameplayCarData.GearPitchMaxValues[currentGearIndex];
            var droppedPitch = currentGearMaxPitch - (currentGearMaxPitch - previousGearMaxPitch) * currentGearConfigData.GearBreathMultiplier * gearCount / gameplayCarData.CurrentGear;

            DOTween.To(() => gameplayCarData.Pitch, i => gameplayCarData.SetPitch(i), droppedPitch, currentGearConfigData.GearBreathDuration).OnComplete(() => gameplayCarData.SetBreath(false));
        }

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
