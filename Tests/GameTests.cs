using AutoMapper;
using KeyStore.Controllers;
using KeyStore.Models;
using KeyStore.Models.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.Extensions.Logging;
using Moq;

namespace Tests
{
    public class GameTests
    {
        [Fact]
        public void Get_ReturnsActualGames()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<GameController>>();
            var mockRepo = new Mock<IGameRepository>();
            var mockMapper = new Mock<IMapper>();
            var expectedGames = new List<Game>
            {
                new Game { id = 1, name = "Starcraft Brood War", price = 500, genre = "RTS" },
                new Game { id = 2, name = "Diablo II", price = 1000, genre = "RPG" },
                new Game { id = 3, name = "Balatro", price = 550, genre = "Rouge Like" },
                new Game { id = 4, name = "Ultrakill", price = 450, genre = "Shooter" },
                new Game { id = 5, name = "Noita", price = 700, genre = "Rouge Like" }
            };
            mockRepo.Setup(repo => repo.GetGames()).Returns(expectedGames);

            var controller = new GameController(mockLogger.Object, mockRepo.Object, mockMapper.Object);

            // Act
            var result = controller.GetGames();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedGames = Assert.IsAssignableFrom<IEnumerable<Game>>(okResult.Value);
            Assert.Equal(expectedGames.Count, returnedGames.Count());
            Assert.Equal(expectedGames, returnedGames);
        }
        [Fact]
        public void Get_ReturnsBadRequestResult_WhenModelStateIsInvalid()
        {
            // Arrange
            var mockLogger = new Mock<ILogger<GameController>>();
            var mockRepo = new Mock<IGameRepository>();
            var mockMapper = new Mock<IMapper>();
            var controller = new GameController(mockLogger.Object, mockRepo.Object, mockMapper.Object);
            controller.ModelState.AddModelError("error", "some error");

            // Act
            var result = controller.GetGames();

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }
    }
}
