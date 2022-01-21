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

  public class TagServiceTests {
    private static readonly Fixture builders = new();
    private Mock<DbSet<Tag>> mockSet;
    private Mock<GameServiceContext> mockContext;
    private Tag testObject;

    public TagServiceTests() {
      mockSet = new Mock<DbSet<Tag>>();
      mockContext = new Mock<GameServiceContext>();
      mockContext.Setup(m => m.Tags).Returns(mockSet.Object);
      testObject = new Tag() {
        Id = 1,
        Name = "Test"
      };

      builders.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
      .ForEach(b => builders.Behaviors.Remove(b));
      builders.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Fact]
    public async Task CreateTag_saveTagDB_CallingSaveChangesAsync() {
      // arrange

      // act
      var service = new TagService(mockContext.Object);
      var result = await service.CreateTag(testObject);

      // assert
      mockSet.Verify(m => m.AddAsync(It.IsAny<Tag>(), It.IsAny<CancellationToken>()), Times.Once());
      mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task UpdateTag_updateTagDB_CallingSaveChangesAsync() {
      // arrange

      // act
      var service = new TagService(mockContext.Object);
      var result = await service.UpdateTag(new Tag() { Name = "Test2", Id = 1 });

      // assert
      mockSet.Verify(m => m.Update(It.IsAny<Tag>()), Times.Once());
      mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task RetrieveDevelopers_developersReplyReturn_ReturnTwoDevelopers() {
      // Arrange
      TagsReply tags = new TagsReply() {
        Tags = GenerateTags().ToList()
      };

      var tagsMock = new Mock<GameServiceContext>();
      tagsMock.Setup(x => x.Tags).ReturnsDbSet(tags.Tags);

      var developersService = new TagService(tagsMock.Object);

      // Act
      var result = await developersService.RetrieveTags();

      // Assert
      Assert.Equal(2, result.Tags.ToList().Count);
    }

    private static IList<Tag> GenerateTags() {
      IList<Tag> tags = new List<Tag>
      {
                builders.Build<Tag>().With(u => u.Name, "First").Create(),
                builders.Build<Tag>().With(u => u.Name, "Second").Create()
      };

      return tags;
    }
  }
}