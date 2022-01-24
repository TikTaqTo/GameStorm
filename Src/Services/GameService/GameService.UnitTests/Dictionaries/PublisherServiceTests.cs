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

  public class PublisherServiceTests {
    private static readonly Fixture builders = new();
    private Mock<DbSet<Publisher>> mockSet;
    private Mock<GameServiceContext> mockContext;
    private Publisher testObject;

    public PublisherServiceTests() {
      mockSet = new Mock<DbSet<Publisher>>();
      mockContext = new Mock<GameServiceContext>();
      mockContext.Setup(m => m.Publishers).Returns(mockSet.Object);
      testObject = new Publisher() {
        Id = 1,
        Name = "Test"
      };

      builders.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
      .ForEach(b => builders.Behaviors.Remove(b));
      builders.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Fact]
    public async Task CreatePublisher_savePublisherDB_CallingSaveChangesAsync() {
      // arrange

      // act
      var service = new PublisherService(mockContext.Object);
      var result = await service.CreatePublisher(testObject);

      // assert
      mockSet.Verify(m => m.AddAsync(It.IsAny<Publisher>(), It.IsAny<CancellationToken>()), Times.Once());
      mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task UpdatePublisher_savePublisherDB_CallingSaveChangesAsync() {
      // arrange

      // act
      var service = new PublisherService(mockContext.Object);
      var result = await service.UpdatePublisher(new Publisher() { Name = "Test2", Id = 1 });

      // assert
      mockSet.Verify(m => m.Update(It.IsAny<Publisher>()), Times.Once());
      mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task RetrievePublisher_publishersReplyReturn_ReturnTwoPublishers() {
      // Arrange
      PublishersReply publishers = new PublishersReply() {
        Publishers = GeneratePublishers().ToList()
      };

      var publishersMock = new Mock<GameServiceContext>();
      publishersMock.Setup(x => x.Publishers).ReturnsDbSet(publishers.Publishers);

      var publishersService = new PublisherService(publishersMock.Object);

      // Act
      var result = await publishersService.RetrievePublishers();

      // Assert
      Assert.Equal(2, result.Publishers.ToList().Count);
    }

    private static IList<Publisher> GeneratePublishers() {
      IList<Publisher> publishers = new List<Publisher>
      {
                builders.Build<Publisher>().With(u => u.Name, "First").Create(),
                builders.Build<Publisher>().With(u => u.Name, "Second").Create()
      };

      return publishers;
    }
  }
}