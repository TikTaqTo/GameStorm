using GameService.Domain.EntityModels.VideoGame;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.Update {

  public class UpdateGameCommand : IRequest<GameReply> {
    public Game Game { get; }

    public UpdateGameCommand(Game game) {
      Game = game;
    }
  }
}