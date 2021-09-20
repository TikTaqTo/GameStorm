using GameService.Domain.EntityModels.Media;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Media.Update {

  public class UpdateImageCommand : IRequest<ImageReply> {
    public Image Image { get; }

    public UpdateImageCommand(Image image) {
      Image = image;
    }
  }
}