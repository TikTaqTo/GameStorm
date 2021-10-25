﻿using GameService.Application.Abstractions.VideoGame;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.AddScreenshot {
  public class AddScreenshotToGameCommandHandler : IRequestHandler<AddScreenshotToGameCommand, GameReply> {
    private readonly IGameService _gameService;

    public AddScreenshotToGameCommandHandler(IGameService gameService) {
      _gameService = gameService;
    }

    public async Task<GameReply> Handle(AddScreenshotToGameCommand request, CancellationToken cancellationToken) {
      return await _gameService.AddScreenshotToGame(request.Request);
    }
  }
}
