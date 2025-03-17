namespace KeyStore.Models.Repository
{
    public interface IGameRepository
    {
        IQueryable<Game> Game { get; }
    }
}
