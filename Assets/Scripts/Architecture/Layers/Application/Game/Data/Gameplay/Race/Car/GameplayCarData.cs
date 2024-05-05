using System;
using SuperGearsGames.Demo.Layers.Data;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Application.Game
{
    public class GameplayCarData
    {
        #region EventHandler

        public event EventHandler CarFinishedEvent;
        public event EventHandler GasPedalPressedEvent;
        public event EventHandler GasPedalReleasedEvent;
        public event EventHandler BrakePedalPressedEvent;
        public event EventHandler BrakePedalReleasedEvent;


        #endregion

        #region Constructor

        public GameplayCarData(CarConfigData carConfigData)
        {
            TotalDistanceTravelled = 0f;
            TotalElapsedDuration = 0f;
            Position = Vector3.zero;
            DidFinish = false;
            ConfigData = carConfigData;
            CurrentGear = 1;
            Speed = 0f;
            IsBreathing = false;
            GasPedalState = GasPedalState.None;
            BrakePedalState = BrakePedalState.None;
            WheelAngle = 0f;
            Pitch = 1f;
            GearPitchMaxValues = new float[carConfigData.EngineConfigData.GearConfigData.MaxGearSpeedArray.Length];

            for (int i = 0; i < GearPitchMaxValues.Length; i++)
            {
                GearPitchMaxValues[i] = Mathf.Lerp(carConfigData.EngineConfigData.GearConfigData.GearMinPitch, carConfigData.EngineConfigData.GearConfigData.GearMaxPitch,
                                        Mathf.InverseLerp(0, carConfigData.EngineConfigData.GearConfigData.MaxGearSpeedArray[carConfigData.EngineConfigData.GearConfigData.MaxGearSpeedArray.Length - 1],
                                        carConfigData.EngineConfigData.GearConfigData.MaxGearSpeedArray[i]));
            }
        }

        #endregion

        #region Data

        public float TotalElapsedDuration { get; private set; }
        public float TotalDistanceTravelled { get; private set; }
        public bool DidFinish { get; private set; }
        public Vector3 Position { get; private set; }
        public int CurrentGear { get; private set; }
        public float Speed { get; private set; }
        public bool IsBreathing { get; private set; }
        public GasPedalState GasPedalState { get; private set; }
        public BrakePedalState BrakePedalState { get; private set; }
        public float WheelAngle { get; private set; }
        public float Pitch { get; private set; }
        public float[] GearPitchMaxValues { get; }

        public CarConfigData ConfigData { get; }

        #endregion


        #region TotalDistanceTravelled: Set

        public void SetTotalDistanceTravelled(float totalDistanceTravelled)
        {
            TotalDistanceTravelled = totalDistanceTravelled;
        }

        #endregion

        #region TotalElapsedDuration: Set

        public void SetTotalElapsedDuration(float totalElapsedDuration)
        {
            TotalElapsedDuration = totalElapsedDuration;
        }

        #endregion

        #region Position: Set

        public void SetPosition(Vector3 position)
        {
            Position = position;
        }

        #endregion

        #region DidFinish: Set

        public void SetDidFinish(bool didFinish)
        {
            DidFinish = didFinish;
            CarFinishedEvent?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region CurrentGear: Set

        public void SetGear(int gear)
        {
            CurrentGear = gear;
        }

        #endregion

        #region Speed: Set

        public void SetSpeed(float speed)
        {
            if (speed < 0)
            {
                Speed = 0;
                return;
            }
            Speed = speed;
        }

        #endregion

        #region BrakePedalState: Set

        public void SetBrakePedal(BrakePedalState pressed)
        {
            BrakePedalState = pressed;
            if (pressed == BrakePedalState.Pressed)
            {
                BrakePedalPressedEvent?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                BrakePedalReleasedEvent?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

        #region GasPedalState: Set

        public void SetGasPedal(GasPedalState pressed)
        {
            GasPedalState = pressed;
            if (pressed == GasPedalState.Pressed)
            {
                GasPedalPressedEvent?.Invoke(this, EventArgs.Empty);
            }
            else
            {
                GasPedalReleasedEvent?.Invoke(this, EventArgs.Empty);
            }
        }

        #endregion

        #region WheelAngle :Set

        public void SetWheelAngle(float angle)
        {
            WheelAngle = angle;
        }

        #endregion

        #region Pitch: Set

        public void SetPitch(float pitch)
        {
            Pitch = pitch;
        }

        #endregion

        #region IsBreathing: Set

        public void SetBreath(bool isBreathing)
        {
            IsBreathing = isBreathing;
        }

        #endregion

    }
}
