using SuperGearsGames.Demo.Layers.Application.Game;
using SuperGearsGames.Demo.Layers.Presentation.Common;
using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Data
{
    [CreateAssetMenu(menuName = "ConfigData/RaceData")]
    public class RaceConfigData : ScriptableObject
    {
        #region Fields

        [SerializeField] private string _id;
        [SerializeField] private float _raceLength;
        [Range(0.001f,0.01f)]
        [SerializeField] private float _frictionMultiplier;
        [SerializeField] private RaceType _raceType;
        [SerializeField] private RaceVisual _raceVisual;

        #endregion

        #region Properties

        public string Id => _id;
        public float RaceLength => _raceLength;
        public float FrictionMultiplier => _frictionMultiplier;
        public RaceType RaceType => _raceType;
        public RaceVisual RaceVisual => _raceVisual;

        #endregion
    }
}
