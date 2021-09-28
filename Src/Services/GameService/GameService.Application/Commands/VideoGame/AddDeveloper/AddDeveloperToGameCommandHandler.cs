using GameService.Application.Abstractions.VideoGame;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.AddDeveloper {
  public class AddDeveloperToGameCommandHandler : IRequestHandler<AddDeveloperToGameCommand, GameReply>{
    private readonly IGameService _gameService;

    public AddDeveloperToGameCommandHandler(IGameService gameService) {
      _gameService = gameService;
    }

    public async Task<GameReply> Handle(AddDeveloperToGameCommand request, CancellationToken cancellationToken) {
      return await _gameService.AddDeveloperToGame(request.Request);
    }
  }
}
