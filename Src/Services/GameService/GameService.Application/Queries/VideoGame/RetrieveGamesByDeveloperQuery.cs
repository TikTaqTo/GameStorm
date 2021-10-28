using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {
  public class RetrieveGamesByDeveloperQuery : IRequest<GamesReply> {
    public RetrieveGamesByDeveloperQuery(string developer) {
      Developer = developer;
    }

    public string Developer { get; }

  }
}
