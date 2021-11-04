using GameService.Application.Abstractions.VideoGame;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {

  public class RetrieveGamesByAllQueryHandler : IRequestHandler<RetrieveGamesByAllQuery, GamesReply> {
    private readonly IGameService _gamesService;

    public RetrieveGamesByAllQueryHandler(IGameService gamesService) {
      _gamesService = gamesService;
    }

    public async Task<GamesReply> Handle(RetrieveGamesByAllQuery request, CancellationToken cancellationToken) {
      return await _gamesService.RetrieveGamesByAllQuery(request.Genre, request.GameSortOrder, request.Platform, request.DateReleaseStart, request.DateReleaseEnd, request.Page, request.PageSize);
    }
  }
}