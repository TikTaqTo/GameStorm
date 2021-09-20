using GameService.Domain.EntityModels.VideoGame;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.Create {

  public class CreateGameCommand : IRequest<GameReply> {
    public Game Game { get; }

    public CreateGameCommand(Game game) {
      Game = game;
    }
  }
}