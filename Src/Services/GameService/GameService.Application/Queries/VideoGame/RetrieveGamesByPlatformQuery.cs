using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {
  public class RetrieveGamesByPlatformQuery : IRequest<GamesReply> {
    public RetrieveGamesByPlatformQuery(string platform) {
      Platform = platform;
    }

    public string Platform { get; }
  }
}
