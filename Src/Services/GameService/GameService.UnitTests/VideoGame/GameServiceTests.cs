using AutoFixture;
using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.EntityModels.VideoGame;
using GameService.Domain.Replies;
using GameService.Infrastructure.Persistence;
using GameService.Infrastructure.Services.Dictionaries;
using GameService.Infrastructure.Services.VideoGame;
using GameService.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GameService.UnitTests.VideoGame {

  public class GameServiceTests {
    private static readonly Fixture builders = new();
    private Mock<DbSet<Game>> mockSet;
    private Mock<GameServiceContext> mockContext;
    private Game testObject;

    public GameServiceTests() {
      mockSet = new Mock<DbSet<Game>>();
      mockContext = new Mock<GameServiceContext>();
      mockContext.Setup(m => m.Games).Returns(mockSet.Object);
      testObject = new Game() {
        Title = "Test game"
        };

      builders.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
      .ForEach(b => builders.Behaviors.Remove(b));
      builders.Behaviors.Add(new OmitOnRecursionBehavior());
      }

    [Fact]
    public async Task CreateGame_saveGameDB_CallingSaveChangesAsync() {
      // arrange

      // act
      var service = new GamesService(mockContext.Object);
      var result = await service.CreateGame(testObject);

      // assert
      mockSet.Verify(m => m.AddAsync(It.IsAny<Game>(), It.IsAny<CancellationToken>()), Times.Once());
      mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
      }

    [Fact]
    public async Task UpdateGame_updateGameDB_CallingSaveChangesAsync() {
      // arrange

      // act
      var service = new GamesService(mockContext.Object);
      var result = await service.UpdateGame(new Game() { Title = "Test2" });

      // assert
      mockSet.Verify(m => m.Update(It.IsAny<Game>()), Times.Once());
      mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
      }

    [Fact]
    public async Task RetrieveGame_gamesReplyReturn_ReturnTwoGames() {
      // Arrange
      GamesReply games = new GamesReply() {
        Games = GenerateGames().ToList()
        };

      var gamesMock = new Mock<GameServiceContext>();
      gamesMock.Setup(x => x.Games).ReturnsDbSet(games.Games);

      var service = new GamesService(gamesMock.Object);

      var expectedCount = GenerateGames().Count();

      // Act
      var result = await service.RetrieveGames();

      // Assert
      Assert.Equal(expectedCount, result.Games.ToList().Count);
      }

    [Fact]
    public async Task RetrieveGameByName_gamesReplyReturn_ReturnOneGames() {
      // Arrange
      GamesReply games = new GamesReply() {
        Games = GenerateGames().ToList()
        };

      var gamesMock = new Mock<GameServiceContext>();
      gamesMock.Setup(x => x.Games).ReturnsDbSet(games.Games);

      var service = new GamesService(gamesMock.Object);

      // Act
      var result = await service.RetrieveGameByName("Second");

      // Assert
      Assert.Equal("Second", result.Game.Title);
      }

    [Fact]
    public async Task RetrieveGamesByName_gamesReplyReturn_ReturnTwoGames() {
      // Arrange
      GamesReply games = new GamesReply() {
        Games = GenerateGames().ToList()
        };

      var gamesMock = new Mock<GameServiceContext>();
      gamesMock.Setup(x => x.Games).ReturnsDbSet(games.Games);

      var service = new GamesService(gamesMock.Object);

      // Act
      var result = await service.RetrieveGamesByName("Gta");

      // Assert
      var fristGame = result.Games.First();
      var secondGame = result.Games.Last();

      Assert.Equal("Gta 5", fristGame.Title);
      Assert.Equal("Gta 4", secondGame.Title);
      }

    [Fact]
    public async Task RetrieveGameById_gamesReplyReturn_ReturnOneGames() {
      // Arrange
      GamesReply games = new GamesReply() {
        Games = GenerateGames().ToList()
        };

      var gamesMock = new Mock<GameServiceContext>();
      gamesMock.Setup(x => x.Games).ReturnsDbSet(games.Games);

      var service = new GamesService(gamesMock.Object);

      // Act
      var result = await service.RetrieveGameById(new Guid("6c69162e-2c6f-42a3-baf2-77b9b026411a"));

      // Assert
      Assert.Equal("6c69162e-2c6f-42a3-baf2-77b9b026411a", result.Game.Id.ToString());
      }

    private static IList<Game> GenerateGames() {
      IList<Game> games = new List<Game>
      {
                builders.Build<Game>().With(g => g.Title, "First").Create(),
                builders.Build<Game>().With(g => g.Title, "Second").Create(),
                builders.Build<Game>().With(g => g.Title, "Gta 5").Create(),
                builders.Build<Game>().With(g => g.Title, "Gta 4").Create(),
                builders.Build<Game>().With(g => g.Id, new Guid("6c69162e-2c6f-42a3-baf2-77b9b026411a")).Create()
      };

      return games;
      }
    }
  }