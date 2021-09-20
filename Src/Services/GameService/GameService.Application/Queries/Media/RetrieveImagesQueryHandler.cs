using GameService.Application.Abstractions.Media;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Queries.Media {

  public class RetrieveImagesQueryHandler : IRequestHandler<RetrieveImagesQuery, ImagesReply> {
    private readonly IImageService _imageService;

    public RetrieveImagesQueryHandler(IImageService imageService) {
      _imageService = imageService;
    }

    public async Task<ImagesReply> Handle(RetrieveImagesQuery request, CancellationToken cancellationToken) {
      return await _imageService.RetrieveImages();
    }
  }
}