using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {
  class RetrieveGamesByTagQueryValidator : AbstractValidator<RetrieveGamesByTagQuery> {
    public RetrieveGamesByTagQueryValidator() {
      RuleFor(x => x.Tag)
        .NotNull()
        .WithMessage("Tag title can not be null")
        .NotEmpty()
        .WithMessage("Tag title can not be empty");
    }
  }
}
