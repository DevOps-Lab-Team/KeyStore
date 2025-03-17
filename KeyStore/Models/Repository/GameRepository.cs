namespace KeyStore.Models.Repository
{
    public class GameRepository : IGameRepository
    {
        private ApplicationDbContext _context;
        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IQueryable<Game> Game => _context.Game;
    }
}
