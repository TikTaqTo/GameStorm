using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.EntityModels.Media;
using GameService.Domain.Replies;
using MediatR;

namespace GameService.Application.Commands.Media.Create {

  public class CreateImageCommand : IRequest<ImageReply> {
    public Image Image { get; }

    public CreateImageCommand(Image image) {
      Image = image;
    }
  }
}