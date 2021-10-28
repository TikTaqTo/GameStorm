using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {
  public class RetrieveGamesByDeveloperQueryValidator : AbstractValidator<RetrieveGamesByDeveloperQuery> {
    public RetrieveGamesByDeveloperQueryValidator() {
      RuleFor(x => x.Developer)
      .NotNull()
      .WithMessage("Developer title can not be null")
      .NotEmpty()
      .WithMessage("Developer title can not be empty");
    }
  }
}
