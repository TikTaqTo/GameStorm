using AutoFixture;
using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using GameService.Infrastructure.Persistence;
using GameService.Infrastructure.Services.Dictionaries;
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

namespace GameService.UnitTests.Dictionaries {

  public class GenreServiceTests {
    private static readonly Fixture builders = new();
    private Mock<DbSet<Genre>> mockSet;
    private Mock<GameServiceContext> mockContext;
    private Genre testObject;

    public GenreServiceTests() {
      mockSet = new Mock<DbSet<Genre>>();
      mockContext = new Mock<GameServiceContext>();
      mockContext.Setup(m => m.Genres).Returns(mockSet.Object);
      testObject = new Genre() {
        Id = 1,
        Name = "Test"
      };

      builders.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
      .ForEach(b => builders.Behaviors.Remove(b));
      builders.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Fact]
    public async Task CreateGenre_saveGenreDB_CallingSaveChangesAsync() {
      // arrange

      // act
      var service = new GenreService(mockContext.Object);
      var result = await service.CreateGenre(testObject);

      // assert
      mockSet.Verify(m => m.AddAsync(It.IsAny<Genre>(), It.IsAny<CancellationToken>()), Times.Once());
      mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task UpdateGenre_updateGenreDB_CallingSaveChangesAsync() {
      // arrange

      // act
      var service = new GenreService(mockContext.Object);
      var result = await service.UpdateGenre(new Genre() { Name = "Test2", Id = 1 });

      // assert
      mockSet.Verify(m => m.Update(It.IsAny<Genre>()), Times.Once());
      mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task RetrieveGenre_genresReplyReturn_ReturnTwoGenres() {
      // Arrange
      GenresReply genres = new GenresReply() {
        Genres = GenerateGenres().ToList()
      };

      var genresMock = new Mock<GameServiceContext>();
      genresMock.Setup(x => x.Genres).ReturnsDbSet(genres.Genres);

      var developersService = new GenreService(genresMock.Object);

      // Act
      var result = await developersService.RetrieveGenres();

      // Assert
      Assert.Equal(2, result.Genres.ToList().Count);
    }

    private static IList<Genre> GenerateGenres() {
      IList<Genre> genres = new List<Genre>
      {
                builders.Build<Genre>().With(u => u.Name, "First").Create(),
                builders.Build<Genre>().With(u => u.Name, "Second").Create()
      };

      return genres;
    }
  }
}