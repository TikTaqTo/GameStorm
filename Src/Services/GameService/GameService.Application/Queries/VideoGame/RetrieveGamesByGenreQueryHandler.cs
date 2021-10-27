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
  public class RetrieveGamesByGenreQueryHandler : IRequestHandler<RetrieveGamesByGenreQuery, GamesReply> {
    private readonly IGameService _gameService;

    public RetrieveGamesByGenreQueryHandler(IGameService gameService) {
      _gameService = gameService;
    }

    public async Task<GamesReply> Handle(RetrieveGamesByGenreQuery request, CancellationToken cancellationToken) {
      return await _gameService.RetrieveGamesByGenre(request.Genre);
    }
  }
}
