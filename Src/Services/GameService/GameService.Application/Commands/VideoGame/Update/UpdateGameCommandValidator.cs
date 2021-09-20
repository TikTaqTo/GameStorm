using FluentValidation;
using GameService.Application.Validators.VideoGame.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.Update {

  public class UpdateGameCommandValidator : AbstractValidator<UpdateGameCommand> {

    public UpdateGameCommandValidator() {
      RuleFor(x => x.Game)
                .SetValidator(new GameValidator())
                .WithMessage("Invalid game entity");
    }
  }
}