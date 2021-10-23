﻿using GameService.Application.Abstractions.VideoGame;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {
  public class RetrieveGamesQueryPaginationHandler : IRequestHandler<RetrieveGamesQueryPagination, GamesReply> {
    private readonly IGameService _gameService;

    public RetrieveGamesQueryPaginationHandler(IGameService gameService) {
      _gameService = gameService;
    }

    public async Task<GamesReply> Handle(RetrieveGamesQueryPagination request, CancellationToken cancellationToken) {
      return await _gameService.RetrieveGamesQueryPagination(request.Page, request.PageSize);
    }
  }
}
