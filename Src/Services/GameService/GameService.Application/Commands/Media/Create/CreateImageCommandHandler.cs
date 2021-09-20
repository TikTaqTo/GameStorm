using GameService.Application.Abstractions.Media;
using GameService.Domain.Replies;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Media.Create {

  internal class CreateImageCommandHandler : IRequestHandler<CreateImageCommand, ImageReply> {
    private readonly IImageService _imageService;

    public CreateImageCommandHandler(IImageService imageService) {
      _imageService = imageService;
    }

    public async Task<ImageReply> Handle(CreateImageCommand request, CancellationToken cancellationToken) {
      return await _imageService.CreateImage(request.Image);
    }
  }
}