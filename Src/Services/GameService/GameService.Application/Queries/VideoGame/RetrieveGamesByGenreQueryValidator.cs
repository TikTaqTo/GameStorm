using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {
  public class RetrieveGamesByGenreQueryValidator : AbstractValidator<RetrieveGamesByGenreQuery> {
    public RetrieveGamesByGenreQueryValidator() {
      RuleFor(x => x.Genre)
        .NotNull()
        .WithMessage("Genre title can not be null")
        .NotEmpty()
        .WithMessage("Genre title can not be empty");
    }
  }
}
