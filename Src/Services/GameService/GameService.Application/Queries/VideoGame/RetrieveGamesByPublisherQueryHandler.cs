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
  public class RetrieveGamesByPublisherQueryHandler : IRequestHandler<RetrieveGamesByPublisherQuery, GamesReply> {
    private readonly IGameService _gameService;

    public RetrieveGamesByPublisherQueryHandler(IGameService gameService) {
      _gameService = gameService;
    }

    public async Task<GamesReply> Handle(RetrieveGamesByPublisherQuery request, CancellationToken cancellationToken) {
      return await _gameService.RetrieveGamesByPublisher(request.Publisher);
    }
  }
}
