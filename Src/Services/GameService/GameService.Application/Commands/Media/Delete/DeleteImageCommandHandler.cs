using GameService.Application.Abstractions.Media;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Media.Delete {

  public class DeleteImageCommandHandler : IRequestHandler<DeleteImageCommand, ImageReply> {
    private readonly IImageService _imageService;

    public DeleteImageCommandHandler(IImageService imageService) {
      _imageService = imageService;
    }

    public async Task<ImageReply> Handle(DeleteImageCommand request, CancellationToken cancellationToken) {
      return await _imageService.DeleteImageById(request.Id);
    }
  }
}