using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {

  public class RetrieveGamesByAllQueryValidator : AbstractValidator<RetrieveGamesByAllQuery> {

    public RetrieveGamesByAllQueryValidator() {
      RuleFor(x => x.Page)
        .NotEmpty()
        .WithMessage("Page can not be empty");

      RuleFor(x => x.PageSize)
        .NotEmpty()
        .WithMessage("Page Size can not be empty");
    }
  }
}