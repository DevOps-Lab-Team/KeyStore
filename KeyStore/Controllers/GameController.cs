using AutoMapper;
using KeyStore.Dto;
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
        private readonly IMapper _mapper;

        public GameController(ILogger<GameController> logger, IGameRepository gameRepo, IMapper mapper)
        {
            _logger = logger;
            this._gameRepository = gameRepo;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Game>))]
        public IActionResult GetGames()
        {
            // var games = _mapper.Map<List<GameDto>>(_gameRepository.GetGames());
            var games = _gameRepository.GetGames();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            return Ok(games);
        }

        [HttpGet("{gameId}")]
        [ProducesResponseType(200, Type = typeof(Game))]
        [ProducesResponseType(400)]
        public IActionResult GetGame(int gameId)
        {
            if(!_gameRepository.GameExists(gameId))
                return NotFound();
            
            var game = _mapper.Map<GameDto>(_gameRepository.GetGame(gameId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(game);
        }

        [HttpPost]
        [ProducesResponseType(201, Type = typeof(GameDto))]
        [ProducesResponseType(400)]
        public IActionResult CreateGame([FromBody] GameDto gameCreate)
        {
            if (gameCreate == null)
                return BadRequest("Game data is null");
            
            var gameEntity = _mapper.Map<Game>(gameCreate);
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var success = _gameRepository.CreateGame(gameEntity);
            if (!success)
                return StatusCode(500, "Something went wrong while saving the game");
            
            var createdGameDto = _mapper.Map<GameDto>(gameEntity);

            return CreatedAtAction(nameof(GetGame), new { gameId = gameEntity.id }, createdGameDto);
        }

        [HttpDelete("{gameId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteGame(int gameId)
        {
            if (!_gameRepository.GameExists(gameId))
                return NotFound();

            var gameToDelete = _gameRepository.GetGame(gameId);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_gameRepository.DeleteGame(gameToDelete))
            {
                _logger.LogError($"An error occured while deleting the game with id {gameId} ({gameToDelete.name})");
                ModelState.AddModelError("", "Game was not deleted. Something went wrong");
                return StatusCode(500, ModelState);
            }
            
            _logger.LogInformation($"Game with id {gameId} ({gameToDelete.name}) has been deleted successfully");
            return NoContent();
        }

        [HttpDelete("by-name/{gameName}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public IActionResult DeleteGameByName(string gameName)
        {
            var gameToDelete = _gameRepository.GetGame(gameName);
            if (gameToDelete == null)
                return NotFound();
            
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!_gameRepository.DeleteGame(gameToDelete))
            {
                _logger.LogError($"An error occured while deleting the game {gameName}");
                ModelState.AddModelError("", "Game was not deleted. Something went wrong");
                return StatusCode(500, ModelState);
            }
            
            _logger.LogInformation($"Game {gameName} has been deletd successfully");
            return NoContent();
        }

        [HttpPut("{gameId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public IActionResult UpdateGame(int gameId, [FromBody] GameDto gameUpdate)
        {
            if (gameUpdate == null)
                return BadRequest("Game data is null");

            var existingGame = _gameRepository.GetGame(gameId);
            if (existingGame == null)
                return NotFound();

            existingGame.name = gameUpdate.name;
            existingGame.price = gameUpdate.price;
            existingGame.genre = gameUpdate.genre;
            existingGame.img = gameUpdate.img;

            if (!_gameRepository.UpdateGame(existingGame))
            {
                _logger.LogError($"An error occured while updating the game with id {gameId} ({gameUpdate.name})");
                ModelState.AddModelError("", "Game was not updated. Something went wrong");
                return StatusCode(500, ModelState);
            }
            
            _logger.LogInformation($"Game with id {gameId} has been updated successfully");
            return NoContent();
        }
        
        [HttpPut("by-name/{name}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateGameByName(string name, [FromBody] GameDto gameUpdate)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingGame = _gameRepository.GetGame(name);
            if (existingGame == null)
                return NotFound();

            existingGame.name = gameUpdate.name;
            existingGame.price = gameUpdate.price;
            existingGame.genre = gameUpdate.genre;
            existingGame.img = gameUpdate.img;

            if (!_gameRepository.UpdateGame(existingGame))
            {
                _logger.LogError($"An error occured while updating the game {name}");
                ModelState.AddModelError("", "Game was not updated. Something went wrong");
                return StatusCode(500, ModelState);
            }

            _logger.LogInformation($"Game {name} has been updated successfully");

            return NoContent();
        }
    }
}
