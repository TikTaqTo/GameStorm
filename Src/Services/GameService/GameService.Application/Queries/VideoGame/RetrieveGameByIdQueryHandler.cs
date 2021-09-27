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
  public class RetrieveGameByIdQueryHandler : IRequestHandler<RetrieveGameByIdQuery, GameReply>{
    private readonly IGameService _gameService;

    public RetrieveGameByIdQueryHandler(IGameService gameService) {
      _gameService = gameService;
    }

    public async Task<GameReply> Handle(RetrieveGameByIdQuery request, CancellationToken cancellationToken) {
      return await _gameService.RetrieveGameById(request.GameId);
    }
  }
}
