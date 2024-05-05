namespace SuperGearsGames.Demo.Initializer
{
    public interface ILayerInitializer
    {
        string Name { get; set; }
        void Init();
    }
}