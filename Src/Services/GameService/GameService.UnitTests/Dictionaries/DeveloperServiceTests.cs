using GameService.Domain.EntityModels.Dictionaries;
using GameService.Infrastructure.Persistence;
using GameService.Infrastructure.Services.Dictionaries;
using Microsoft.EntityFrameworkCore;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace GameService.UnitTests.Dictionaries {

  public class DeveloperServiceTests {
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
    }

    [Fact]
    public async Task CreateDeveloper_saveDeveloperDB_ReturnDeveloperReply() {
      // arrange

      // act
      var service = new DeveloperService(mockContext.Object);
      var result = await service.CreateDeveloper(testObject);

      // assert
      mockSet.Verify(m => m.AddAsync(It.IsAny<Developer>(), It.IsAny<CancellationToken>()), Times.Once());
      mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task UpdateDeveloper_saveDeveloperDB_ReturnDeveloperReply() {
      // arrange

      // act
      var service = new DeveloperService(mockContext.Object);
      var result = await service.UpdateDeveloper(new Developer() { SeoTitle = "Test2", Id = 1 });

      // assert
      mockSet.Verify(m => m.Update(It.IsAny<Developer>()), Times.Once());
      mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }
  }
}