using FluentValidation;
using GameService.Application.Validators.VideoGame.Games;
using GameService.Domain.Replies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.Create {

  public class CreateGameCommandValidator : AbstractValidator<GameReply> {

    public CreateGameCommandValidator() {
      RuleFor(x => x.Game)
                .SetValidator(new GameValidator())
                .WithMessage("Invalid game entity");
    }
  }
}