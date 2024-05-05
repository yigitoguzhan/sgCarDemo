namespace SuperGearsGames.Demo.Layers.Data.Repositories
{
    public interface IScriptableConfigDataRepository
    {
        string Path { get; }
        public void Load();
    }
}