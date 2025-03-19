namespace KeyStore.Models.Repository
{
    public interface IGameRepository
    {
        ICollection<Game> GetGames { get; }
    }
}
