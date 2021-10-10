using GameService.Application.Abstractions.Media;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Queries.Media {
  public class RetrieveImagesByGameIdQueryHandler : IRequestHandler<RetrieveImagesByGameIdQuery, ImagesReply> {
    private readonly IImageService _imageService;

    public RetrieveImagesByGameIdQueryHandler(IImageService imageService) {
      _imageService = imageService;
    }

    public async Task<ImagesReply> Handle(RetrieveImagesByGameIdQuery request, CancellationToken cancellationToken) {
      return await _imageService.RetrieveImagesByGameId(request.GameId); 
    }
  }
}
