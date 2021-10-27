using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {
  public class RetrieveGamesByPlatformQueryValidator : AbstractValidator<RetrieveGamesByPlatformQuery> {
    public RetrieveGamesByPlatformQueryValidator() {
      RuleFor(x => x.Platform)
        .NotNull()
        .WithMessage("Platform title can not be null")
        .NotEmpty()
        .WithMessage("Platform title can not be empty");
    }
  }
}
