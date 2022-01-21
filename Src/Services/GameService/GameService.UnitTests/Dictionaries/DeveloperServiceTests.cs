using AutoFixture;
using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using GameService.Infrastructure.Persistence;
using GameService.Infrastructure.Services.Dictionaries;
using GameService.Shared.Extensions;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GameService.UnitTests.Dictionaries {

  public class DeveloperServiceTests {
    private static readonly Fixture builders = new();
    private Mock<DbSet<Developer>> mockSet;
    private Mock<GameServiceContext> mockContext;
    private Developer testObject;

    public DeveloperServiceTests() {
      mockSet = new Mock<DbSet<Developer>>();
      mockContext = new Mock<GameServiceContext>();
      mockContext.Setup(m => m.Developers).Returns(mockSet.Object);
      testObject = new Developer() {
        Id = 1,
        SeoTitle = "Test"
      };

      builders.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
      .ForEach(b => builders.Behaviors.Remove(b));
      builders.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Fact]
    public async Task CreateDeveloper_saveDeveloperDB_CallingSaveChangesAsync() {
      // arrange

      // act
      var service = new DeveloperService(mockContext.Object);
      var result = await service.CreateDeveloper(testObject);

      // assert
      mockSet.Verify(m => m.AddAsync(It.IsAny<Developer>(), It.IsAny<CancellationToken>()), Times.Once());
      mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task UpdateDeveloper_saveDeveloperDB_CallingSaveChangesAsync() {
      // arrange

      // act
      var service = new DeveloperService(mockContext.Object);
      var result = await service.UpdateDeveloper(new Developer() { SeoTitle = "Test2", Id = 1 });

      // assert
      mockSet.Verify(m => m.Update(It.IsAny<Developer>()), Times.Once());
      mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task RetrieveDevelopers_developersReplyReturn_ReturnTwoDevelopers() {
      // Arrange
      DevelopersReply developers = new DevelopersReply() {
        Developers = GenerateDevelopers().ToList()
      };

      var developersMock = new Mock<GameServiceContext>();
      developersMock.Setup(x => x.Developers).ReturnsDbSet(developers.Developers);

      var developersService = new DeveloperService(developersMock.Object);

      // Act
      var result = await developersService.RetrieveDevelopers();

      // Assert
      Assert.Equal(2, result.Developers.ToList().Count);
    }

    private static IList<Developer> GenerateDevelopers() {
      IList<Developer> developers = new List<Developer>
      {
                builders.Build<Developer>().With(u => u.SeoTitle, "First").Create(),
                builders.Build<Developer>().With(u => u.SeoTitle, "Second").Create()
      };

      return developers;
    }
  }
}