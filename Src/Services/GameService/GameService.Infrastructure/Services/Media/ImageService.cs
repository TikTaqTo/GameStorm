using GameService.Application.Abstractions.Media;
using GameService.Domain.EntityModels.Media;
using GameService.Domain.Replies;
using GameService.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Infrastructure.Services.Media {

  public class ImageService : IImageService {
    private readonly GameServiceContext _context;

    public ImageService(GameServiceContext context) {
      _context = context;
    }

    public async Task<ImageReply> CreateImage(Image image) {
      await _context.Images.AddAsync(image);
      await _context.SaveChangesAsync();
      return new ImageReply() {
        Image = image
      };
    }

    public async Task<ImageReply> DeleteImageById(Guid id) {
      var image = _context.Images.Find(id);
      image.DeletedAt = DateTimeOffset.Now;
      image.DeletedBy = "admin";
      image.DeletedReason = "delete info";
      await _context.SaveChangesAsync();
      return new ImageReply {
        Image = image
      };
    }

    public async Task<ImagesReply> RetrieveImages() {
      var allImage = _context.Images;
      var imagesReply = new ImagesReply() {
        Images = allImage
      };
      return await Task.FromResult(imagesReply);
    }

    public async Task<ImageReply> UpdateImage(Image image) {
      var newImage = _context.Images.Find(image);
      newImage.Name = image.Name;
      newImage.GameId = image.GameId;
      newImage.ModifiedAt = DateTimeOffset.Now;
      newImage.ModifiedBy = "admin";
      await _context.SaveChangesAsync();
      return new ImageReply() {
        Image = image
      };
    }
  }
}