using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {
  public class RetrieveGamesByNameQuery : IRequest<GamesReply> {
    public string GameTitle { get; }

    public RetrieveGamesByNameQuery(string gameTitle) {
      GameTitle = gameTitle;
    }
  }
}
