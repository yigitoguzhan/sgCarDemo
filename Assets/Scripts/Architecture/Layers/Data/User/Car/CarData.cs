namespace SuperGearsGames.Demo.Layers.Data.Repositories
{
    public class CarData
    {
        public CarData(string id, bool isOwned,CarConfigData carConfigData)
        {
            Id = id;
            IsOwned = isOwned;
            Config = carConfigData;
        }

        public string Id { get; private set; }
        public bool IsOwned { get; private set; }
        public CarConfigData Config { get; private set; }

        public void SetIsOwned(bool isOwned)
        {
            IsOwned = isOwned;
        }
    }
}