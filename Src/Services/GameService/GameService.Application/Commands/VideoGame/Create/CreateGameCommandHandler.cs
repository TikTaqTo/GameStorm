using GameService.Application.Abstractions.VideoGame;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.Create {

  public class CreateGameCommandHandler : IRequestHandler<CreateGameCommand, GameReply> {
    private readonly IGameService _gameService;

    public CreateGameCommandHandler(IGameService gameService) {
      _gameService = gameService;
    }

    public async Task<GameReply> Handle(CreateGameCommand request, CancellationToken cancellationToken) {
      return await _gameService.CreateGame(request.Game);
    }
  }
}