using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {
  public class RetrieveGameByNameQuery : IRequest<GameReply> {
    public string GameTitle { get; }

    public RetrieveGameByNameQuery(string gameTitle) {
      GameTitle = gameTitle;
    }
  }
}
