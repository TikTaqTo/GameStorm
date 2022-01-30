using AutoFixture;
using GameService.Domain.EntityModels.Media;
using GameService.Domain.Replies;
using GameService.Infrastructure.Persistence;
using GameService.Infrastructure.Services.Media;
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

namespace GameService.UnitTests.Media
{
  public class ImageServiceTests
  {
    private static readonly Fixture builders = new();
    private Mock<DbSet<Image>> mockSet;
    private Mock<GameServiceContext> mockContext;
    private Image testObject;

    public ImageServiceTests()
    {
      mockSet = new Mock<DbSet<Image>>();
      mockContext = new Mock<GameServiceContext>();
      mockContext.Setup(m => m.Images).Returns(mockSet.Object);
      testObject = new Image()
      {
        Name = "Test"
      };

      builders.Behaviors.OfType<ThrowingRecursionBehavior>().ToList()
      .ForEach(b => builders.Behaviors.Remove(b));
      builders.Behaviors.Add(new OmitOnRecursionBehavior());
    }

    [Fact]
    public async Task CreateImage_saveImageDB_CallingSaveChangesAsync()
    {
      // arrange

      // act
      var service = new ImageService(mockContext.Object);
      var result = await service.CreateImage(testObject);

      // assert
      mockSet.Verify(m => m.AddAsync(It.IsAny<Image>(), It.IsAny<CancellationToken>()), Times.Once());
      mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task UpdateImage_updateImageDB_CallingSaveChangesAsync()
    {
      // arrange

      // act
      var service = new ImageService(mockContext.Object);
      var result = await service.UpdateImage(new Image() { Name = "Test2" });

      // assert
      mockSet.Verify(m => m.Update(It.IsAny<Image>()), Times.Once());
      mockContext.Verify(m => m.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once());
    }

    [Fact]
    public async Task RetrieveImage_imagesReplyReturn_ReturnTwoImages()
    {
      // Arrange
      ImagesReply images = new ImagesReply()
      {
        Images = GenerateImages().ToList()
      };

      var imagesMock = new Mock<GameServiceContext>();
      imagesMock.Setup(x => x.Images).ReturnsDbSet(images.Images);

      var developersService = new ImageService(imagesMock.Object);

      // Act
      var result = await developersService.RetrieveImages();

      // Assert
      Assert.Equal(2, result.Images.ToList().Count);
    }

    private static IList<Image> GenerateImages()
    {
      IList<Image> images = new List<Image>
      {
                builders.Build<Image>().With(u => u.Name, "First").Create(),
                builders.Build<Image>().With(u => u.Name, "Second").Create()
      };

      return images;
    }
  }
}