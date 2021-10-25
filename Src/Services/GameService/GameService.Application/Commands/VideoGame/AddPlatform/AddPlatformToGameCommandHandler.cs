using GameService.Application.Abstractions.VideoGame;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.AddPlatform {
  public class AddPlatformToGameCommandHandler : IRequestHandler<AddPlatformToGameCommand, GameReply> {
    private readonly IGameService _gameService;

    public AddPlatformToGameCommandHandler(IGameService gameService) {
      _gameService = gameService;
    }

    public async Task<GameReply> Handle(AddPlatformToGameCommand request, CancellationToken cancellationToken) {
      return await _gameService.AddPlatformToGame(request.Request);
    }
  }
}
