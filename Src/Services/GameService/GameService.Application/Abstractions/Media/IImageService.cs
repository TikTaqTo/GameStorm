using GameService.Domain.EntityModels.Media;
using GameService.Domain.Replies;
using System;
using System.Threading.Tasks;

namespace GameService.Application.Abstractions.Media {

  public interface IImageService {

    Task<ImageReply> CreateImage(Image image);

    Task<ImageReply> UpdateImage(Image image);

    Task<ImagesReply> RetrieveImages();

    Task<ImagesReply> RetrieveImagesByGameId(Guid gameId);

    Task<ImageReply> DeleteImageById(Guid id);
  }
}