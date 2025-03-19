namespace KeyStore.Models.Repository
{
    public class GameRepository : IGameRepository
    {
        private ApplicationDbContext _context;
        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public ICollection<Game> GetGames => _context.Game.OrderBy(p => p.id).ToList();
    }
}
