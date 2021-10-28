using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {
  public class RetrieveGamesByPublisherQuery : IRequest<GamesReply> {
    public RetrieveGamesByPublisherQuery(string publisher) {
      Publisher = publisher;
    }

    public string Publisher { get; }
  }
}
