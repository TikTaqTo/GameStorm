using FluentValidation;
using GameService.Domain.EntityModels.VideoGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Validators.VideoGame.Games {

  public class GameValidator : AbstractValidator<Game> {

    public GameValidator() {
      RuleFor(x => x.Title)
        .NotNull()
        .WithMessage("Game title can not be null")
        .NotEmpty()
        .WithMessage("Game title can not be empty")
        .MaximumLength(200)
        .WithMessage("Game title can not be more than 200 chars");
    }
  }
}