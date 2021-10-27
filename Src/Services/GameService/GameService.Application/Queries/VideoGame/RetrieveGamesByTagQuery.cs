using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {
  public class RetrieveGamesByTagQuery : IRequest<GamesReply> {
    public RetrieveGamesByTagQuery(string tag) {
      Tag = tag;
    }

    public string Tag { get; }
  }
}
