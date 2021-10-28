using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {
  public class RetrieveGamesByPublisherQueryValidator : AbstractValidator<RetrieveGamesByPublisherQuery> {
    public RetrieveGamesByPublisherQueryValidator() {
      RuleFor(x => x.Publisher)
        .NotNull()
        .WithMessage("Publisher title can not be null")
        .NotEmpty()
        .WithMessage("Publisher title can not be empty");
    }
  }
}
