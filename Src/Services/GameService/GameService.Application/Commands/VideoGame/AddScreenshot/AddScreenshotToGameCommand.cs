using GameService.Domain.Replies;
using GameService.Domain.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.AddScreenshot {
  public class AddScreenshotToGameCommand : IRequest<GameReply> {
    public AddScreenshotToGameRequest Request { get; }

    public AddScreenshotToGameCommand(AddScreenshotToGameRequest request) {
      Request = request;
    }
  }
}
