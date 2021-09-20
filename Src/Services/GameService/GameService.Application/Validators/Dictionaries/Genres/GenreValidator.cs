using FluentValidation;
using GameService.Domain.EntityModels.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Validators.Dictionaries.Genres {

  public class GenreValidator : AbstractValidator<Genre> {

    public GenreValidator() {
      RuleFor(x => x.Name)
        .NotNull()
        .WithMessage("Genre name can not be null")
        .NotEmpty()
        .WithMessage("Genre name can not be empty")
        .MaximumLength(200)
        .WithMessage("Genre name can not be more than 200 chars");
    }
  }
}