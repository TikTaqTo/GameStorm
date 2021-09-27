using GameService.Application.Abstractions.VideoGame;
using GameService.Domain.Replies;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {
  public class RetrieveGameByNameQueryHandler : IRequestHandler<RetrieveGameByNameQuery, GameReply> {
    private readonly IGameService _gameService;

    public RetrieveGameByNameQueryHandler(IGameService gameService) {
      _gameService = gameService;
    }

    public async Task<GameReply> Handle(RetrieveGameByNameQuery request, CancellationToken cancellationToken) {
      return await _gameService.RetrieveGameByName(request.GameTitle);
    }
  }
}
