using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Data
{
    [CreateAssetMenu(menuName = "ConfigData/CarData/GearData")]
    public class GearConfigData : ScriptableObject
    {
        #region Fields
        [SerializeField] private float _gearMinPitch;
        [SerializeField] private float _gearMaxPitch;
        [Range(.5f, 1f)]
        [SerializeField] private float _gearPitchRecoveryRate;
        [Range(.1f, 2)]
        [SerializeField] private float _gearBreathMultiplier;
        [Range(.05f, 0.3f)]
        [SerializeField] private float _gearBreathDuration;
        [Range(.05f, .1f)]
        [SerializeField] private float _gearToleranceRate;
        [SerializeField] private GearType _gearType;
        [SerializeField] private int _gearCount;
        [SerializeField] private float[] _maxGearSpeedArray;

        #endregion

        #region Properties
        public float GearMinPitch => _gearMinPitch;
        public float GearMaxPitch => _gearMaxPitch;
        public float GearPitchRecoveryRate => _gearPitchRecoveryRate;
        public float GearBreathMultiplier => _gearBreathMultiplier;
        public float GearBreathDuration => _gearBreathDuration;
        public float GearToleranceRate => _gearToleranceRate;
        public GearType GearType => _gearType;
        public int GearCount => _gearCount;
        public float[] MaxGearSpeedArray => _maxGearSpeedArray;

        #endregion
    }

    public enum GearType
    {
        Automatic,
        Manual,
        Hybrid
    }
}
