using GameService.Application.Abstractions.VideoGame;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.AddGenre {
  public class AddGenreToGameCommandHandler : IRequestHandler<AddGenreToGameCommand, GameReply> {
    private readonly IGameService _gameService;

    public AddGenreToGameCommandHandler(IGameService gameService) {
      _gameService = gameService;
    }

    public async Task<GameReply> Handle(AddGenreToGameCommand request, CancellationToken cancellationToken) {
      return await _gameService.AddGenreToGame(request.Request);
    }
  }
}
