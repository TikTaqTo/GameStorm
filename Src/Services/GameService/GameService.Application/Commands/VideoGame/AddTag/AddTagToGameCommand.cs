using GameService.Domain.Replies;
using GameService.Domain.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.AddTag {
  public class AddTagToGameCommand : IRequest<GameReply> {
    public AddTagToGameRequest Request { get; }

    public AddTagToGameCommand(AddTagToGameRequest request) {
      Request = request;
    }
  }
}
