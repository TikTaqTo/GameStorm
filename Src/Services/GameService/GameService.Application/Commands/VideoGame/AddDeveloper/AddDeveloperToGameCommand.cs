using GameService.Domain.Replies;
using GameService.Domain.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.AddDeveloper {
  public class AddDeveloperToGameCommand : IRequest<GameReply> {
    public AddDeveloperToGameRequest Request { get; }

    public AddDeveloperToGameCommand(AddDeveloperToGameRequest request) {
      Request = request;
    }
  }
}
