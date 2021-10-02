﻿using FluentValidation;
using GameService.Application.Validators.Dictionaries.Genres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Genres.Create {

  public class CreateGenreCommandValidator : AbstractValidator<CreateGenreCommand> {

    public CreateGenreCommandValidator() {
      RuleFor(x => x.Genre)
        .SetValidator(new GenreValidator())
        .WithMessage("Invalid genre entity");
    }
  }
}