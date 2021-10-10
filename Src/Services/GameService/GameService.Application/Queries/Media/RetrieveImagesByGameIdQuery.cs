using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.Media {
  public class RetrieveImagesByGameIdQuery : IRequest<ImagesReply> {
    public Guid GameId { get; }

    public RetrieveImagesByGameIdQuery(Guid gameId) {
      GameId = gameId;
    }
  }
}
