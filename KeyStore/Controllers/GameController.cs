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
        [ProducesResponseType(200, Type = typeof(IEnumerable<Game>))]
        public IActionResult Get()
        {
            var games = _gameRepository.GetGames;
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(games);
        }
    }
}
