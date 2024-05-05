using SuperGearsGames.Demo.Layers.Application.Game;

namespace SuperGearsGames.Demo.Layers.Presentation.Game
{
    public class GameplayRaceInfoOverlayModelData : ModelData
    {
        #region Constructor

        public GameplayRaceInfoOverlayModelData(GameplayData gameplayData)
        {
            GameplayData = gameplayData;
            CountdownTimer = 5;
            CarTimerValue = 0;
        }

        #endregion

        #region Data

        public GameplayData GameplayData { get; }
        public int CountdownTimer { get; private set; }
        public float CarTimerValue { get; private set; }

        #endregion

        #region Set: Countdown

        public void SetCountdown(int countDown)
        {
            CountdownTimer = countDown;
        }

        #endregion

        #region Set: CarTimerValue

        public void SetCarTimerValue(float carTimerValue)
        {
            CarTimerValue = carTimerValue;
        }

        #endregion

    }

    public class GameplayRaceInfoOverlayModel : Model<GameplayRaceInfoOverlayModelData>
    {
        #region Constructor

        public GameplayRaceInfoOverlayModel(GameplayRaceInfoOverlayModelData data) : base(data)
        {
        }

        #endregion

        #region Data

        public GameplayData GameplayData => Data.GameplayData;
        public int CountdownTimer => Data.CountdownTimer;
        public float CarTimerValue => Data.CarTimerValue;

        #endregion

        #region Set: Countdown

        public void SetCountdown(int countDown)
        {
            Data.SetCountdown(countDown);
        }

        #endregion

        #region Set: CarTimerValue

        public void SetCarTimerValue(float carTimerValue)
        {
            Data.SetCarTimerValue(carTimerValue);
        }

        #endregion
    }
}
