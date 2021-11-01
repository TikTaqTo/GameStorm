using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {

  public class RetrieveGamesAtCreatedYearQueryValidator : AbstractValidator<RetrieveGamesAtCreatedYearQuery> {

    public RetrieveGamesAtCreatedYearQueryValidator() {
      RuleFor(x => x.Date)
      .NotNull()
      .WithMessage("Date can not be null")
      .NotEmpty()
      .WithMessage("Date can not be empty");
    }
  }
}