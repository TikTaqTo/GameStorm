using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {
  public class RetrieveGamesByGenreQuery : IRequest<GamesReply> {
    public RetrieveGamesByGenreQuery(string genre) {
      Genre = genre;
    }

    public string Genre { get; }
  }
}
