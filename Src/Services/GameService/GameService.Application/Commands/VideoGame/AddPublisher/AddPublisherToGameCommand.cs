using GameService.Domain.Replies;
using GameService.Domain.Requests;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.AddPublisher {
  public class AddPublisherToGameCommand : IRequest<GameReply> {
    public AddPublisherToGameRequest Request { get; }

    public AddPublisherToGameCommand(AddPublisherToGameRequest request) {
      Request = request;
    }
  }
}
