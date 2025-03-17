using KeyStore.Models;
using KeyStore.Models.Repository;
using Microsoft.AspNetCore.Mvc;

namespace KeyStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GameController : ControllerBase
    {
        private readonly ILogger<GameController> _logger;
        private readonly IGameRepository _gameRepository;

        public GameController(ILogger<GameController> logger, IGameRepository gameRepo)
        {
            _logger = logger;
            this._gameRepository = gameRepo;
        }

        [HttpGet(Name = "GetGames")]
        public IEnumerable<Game> Get()
        {
            return _gameRepository.Game.ToList();
        }
    }
}
