using GameService.Domain.EntityModels.VideoGame;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.Delete {

  public class DeleteGameCommand : IRequest<GameReply> {
    public Guid Id { get; }

    public DeleteGameCommand(Guid id) {
      Id = id;
    }
  }
}