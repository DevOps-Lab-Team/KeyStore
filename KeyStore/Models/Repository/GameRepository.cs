namespace KeyStore.Models.Repository
{
    public class GameRepository : IGameRepository
    {
        private ApplicationDbContext _context;
        public GameRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public ICollection<Game> GetGames() => _context.Game.OrderBy(p => p.id).ToList();
        public Game GetGame(int id) => _context.Game.Where(p => p.id == id).FirstOrDefault();
        public Game GetGame(string name) => _context.Game.Where(p => p.name == name).FirstOrDefault();
        public bool GameExists(int id) => _context.Game.Any(p => p.id == id);
        public bool CreateGame(Game game)
        {
            _context.Game.Add(game);
            return Save();
        }
        public bool DeleteGame(Game game)
        {
            _context.Game.Remove(game);
            return Save();
        }

        public bool UpdateGame(Game game)
        {
            _context.Game.Update(game);
            return Save();
        }
        
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
