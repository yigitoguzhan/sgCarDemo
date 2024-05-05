using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Data
{
    [CreateAssetMenu(menuName = "ConfigData/CarData/EngineData")]
    public class EngineConfigData : ScriptableObject
    {
        #region Fields

        [SerializeField] private int _horsePower;
        [SerializeField] private GearConfigData _gearConfigData;


        #endregion

        #region Properties

        public int HorsePower => _horsePower;
        public GearConfigData GearConfigData => _gearConfigData;

        #endregion
    }
}
