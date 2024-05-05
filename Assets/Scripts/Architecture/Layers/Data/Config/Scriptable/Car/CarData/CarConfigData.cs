using SuperGearsGames.Demo.Layers.Presentation.Common;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Data
{
    [CreateAssetMenu(menuName = "ConfigData/CarData")]
    public class CarConfigData : ScriptableObject
    {
        #region Fields

        [SerializeField] private string _id;
        [SerializeField] private float _chasisMass;
        [SerializeField] private float _breakForce;
        [SerializeField] private float _wheelRadius;
        [SerializeField] private float _carForwardPoint;

        [SerializeField] private EngineConfigData _engineConfigData;
        [SerializeField] private CarVisual _carVisual;

        #endregion

        #region Properties

        public string Id => _id;
        public float ChasisMass => _chasisMass;
        public float BreakForce => _breakForce;
        public float WheelRadius => _wheelRadius;
        public float CarForwardPoint => _carForwardPoint;
        public EngineConfigData EngineConfigData => _engineConfigData; 
        public CarVisual CarVisual => _carVisual;

        #endregion
    }
}
