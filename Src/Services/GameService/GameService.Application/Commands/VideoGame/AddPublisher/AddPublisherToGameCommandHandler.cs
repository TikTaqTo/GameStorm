using GameService.Application.Abstractions.VideoGame;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.AddPublisher {
  public class AddPublisherToGameCommandHandler : IRequestHandler<AddPublisherToGameCommand, GameReply> {
    private readonly IGameService _gameService;

    public AddPublisherToGameCommandHandler(IGameService gameService) {
      _gameService = gameService;
    }

    public async Task<GameReply> Handle(AddPublisherToGameCommand request, CancellationToken cancellationToken) {
      return await _gameService.AddPublisherToGame(request.Request);
    }
  }
}
