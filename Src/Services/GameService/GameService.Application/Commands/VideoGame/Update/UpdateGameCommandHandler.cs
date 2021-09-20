using GameService.Application.Abstractions.VideoGame;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.Update {

  public class UpdateGameCommandHandler : IRequestHandler<UpdateGameCommand, GameReply> {
    private readonly IGameService _gameService;

    public UpdateGameCommandHandler(IGameService gameService) {
      _gameService = gameService;
    }

    public async Task<GameReply> Handle(UpdateGameCommand request, CancellationToken cancellationToken) {
      return await _gameService.UpdateGame(request.Game);
    }
  }
}