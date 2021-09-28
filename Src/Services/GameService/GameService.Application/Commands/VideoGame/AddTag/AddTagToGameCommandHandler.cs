using GameService.Application.Abstractions.VideoGame;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.AddTag {
  class AddTagToGameCommandHandler : IRequestHandler<AddTagToGameCommand, GameReply> {
    private readonly IGameService _gameService;

    public AddTagToGameCommandHandler(IGameService gameService) {
      _gameService = gameService;
    }

    public async Task<GameReply> Handle(AddTagToGameCommand request, CancellationToken cancellationToken) {
      return await _gameService.AddTagToGame(request.Request);
    }
  }
}
