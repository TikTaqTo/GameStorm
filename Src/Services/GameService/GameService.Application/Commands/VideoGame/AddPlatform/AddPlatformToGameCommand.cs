using GameService.Domain.Replies;
using GameService.Domain.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.AddPlatform {
  public class AddPlatformToGameCommand : IRequest<GameReply> {
    public AddPlatformToGameRequest Request { get; }

    public AddPlatformToGameCommand(AddPlatformToGameRequest request) {
      Request = request;
    }
  }
}
