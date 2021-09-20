using FluentValidation;
using GameService.Application.Validators.VideoGame.Games;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.VideoGame.Delete {

  public class DeleteGameCommandValidator : AbstractValidator<DeleteGameCommand> {

    public DeleteGameCommandValidator() {
      RuleFor(x => x.Id)
        .NotNull()
        .WithMessage("Game Id cannot be null");
    }
  }
}