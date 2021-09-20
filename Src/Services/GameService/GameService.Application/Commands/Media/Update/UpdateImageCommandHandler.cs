using GameService.Application.Abstractions.Media;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Media.Update {

  public class UpdateImageCommandHandler : IRequestHandler<UpdateImageCommand, ImageReply> {
    private readonly IImageService _imageService;

    public UpdateImageCommandHandler(IImageService imageService) {
      _imageService = imageService;
    }

    public async Task<ImageReply> Handle(UpdateImageCommand request, CancellationToken cancellationToken) {
      return await _imageService.UpdateImage(request.Image);
    }
  }
}