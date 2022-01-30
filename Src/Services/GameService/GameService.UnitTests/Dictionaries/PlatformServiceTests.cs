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

namespace GameService.UnitTests.Dictionaries
{
  public class PlatformServiceTests
  {
    private static readonly Fixture builders = new();
    private Mock<DbSet<Platform>> mockSet;
    private Mock<GameServiceContext> mockContext;
    private Platform testObject;

    public PlatformServiceTests()
    {
      mockSet = new Mock<DbSet<Platform>>();
      mockContext = new Mock<GameServiceContext>();
      mockContext.Setup(m => m.Platforms).Returns(mockSet.Object);
      testObject = new Platform()
      {
        Id = 1,
        Name = "Test"
      };

      builders.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
      .ForEach(b => builders.Behaviors.Remove(b));
      builders.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Fact]
    public async Task CreatePlatform_savePlatformDB_CallingSaveChangesAsync()
    {
      // arrange

      // act
      var service = new PlatformService(mockContext.Object);
      var result = await service.CreatePlatform(testObject);

      // assert
      mockSet.Verify(m => m.AddAsync(It.IsAny<Platform>(), It.IsAny<CancellationToken>()), Times.Once());
      mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task UpdatePlatform_updatePlatformDB_CallingSaveChangesAsync()
    {
      // arrange

      // act
      var service = new PlatformService(mockContext.Object);
      var result = await service.UpdatePlatform(new Platform() { Name = "Test2", Id = 1 });

      // assert
      mockSet.Verify(m => m.Update(It.IsAny<Platform>()), Times.Once());
      mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task RetrievePlatform_platformsReplyReturn_ReturnTwoPlatforms()
    {
      // Arrange
      PlatformsReply platforms = new PlatformsReply()
      {
        Platforms = GeneratePlatforms().ToList()
      };

      var platformsMock = new Mock<GameServiceContext>();
      platformsMock.Setup(x => x.Platforms).ReturnsDbSet(platforms.Platforms);

      var developersService = new PlatformService(platformsMock.Object);

      // Act
      var result = await developersService.RetrievePlatforms();

      // Assert
      Assert.Equal(2, result.Platforms.ToList().Count);
    }

    private static IList<Platform> GeneratePlatforms()
    {
      IList<Platform> platforms = new List<Platform>
      {
                builders.Build<Platform>().With(u => u.Name, "First").Create(),
                builders.Build<Platform>().With(u => u.Name, "Second").Create()
      };

      return platforms;
    }
  }
}