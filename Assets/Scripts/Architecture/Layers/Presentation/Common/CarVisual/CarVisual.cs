using UnityEngine;

namespace SuperGearsGames.Demo.Layers.Presentation.Common
{
    public class CarVisual : MonoBehaviour
    {
        #region Fields

        [Header("CarSounds")]
        [SerializeField]
        private AudioSource _asRunningSound;
        public AudioSource RunningSound => _asRunningSound;

        [Header("BrakeLights")]
        [SerializeField]
        private GameObject _goBrakeLights;
        public GameObject BrakeLights => _goBrakeLights;

        [Header("FrontWheels")]
        [SerializeField]
        private Transform _transformFrontWheels;
        public Transform FrontWheels => _transformFrontWheels;

        [Header("BackWheels")]
        [SerializeField]
        private Transform _transformBackWheels;
        public Transform BackWheels => _transformBackWheels;

        #endregion

    }
}
