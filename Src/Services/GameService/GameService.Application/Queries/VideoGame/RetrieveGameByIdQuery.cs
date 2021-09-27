using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {
  public class RetrieveGameByIdQuery : IRequest<GameReply> {
    public Guid GameId { get; }

    public RetrieveGameByIdQuery(Guid gameId) {
      GameId = gameId;
    }
  }
}
