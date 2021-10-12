using GameService.Application.Abstractions.VideoGame;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.Delete {

  public class DeleteGameCommandHandler : IRequestHandler<DeleteGameCommand, GameReply> {
    private readonly IGameService _gameService;

    public DeleteGameCommandHandler(IGameService gameService) {
      _gameService = gameService;
    }

    public async Task<GameReply> Handle(DeleteGameCommand request, CancellationToken cancellationToken) {
      return await _gameService.DeleteGameById(request.Id);
    }
  }
}