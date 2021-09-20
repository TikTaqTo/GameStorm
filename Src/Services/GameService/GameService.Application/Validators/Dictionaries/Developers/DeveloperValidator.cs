using FluentValidation;
using GameService.Domain.EntityModels.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Validators.Dictionaries.Developers {

  public class DeveloperValidator : AbstractValidator<Developer> {

    public DeveloperValidator() {
      RuleFor(x => x.SeoTitle)
        .NotNull()
        .WithMessage("Developer team name can not be null")
        .NotEmpty()
        .WithMessage("Developer team name can not be empty")
        .MaximumLength(200)
        .WithMessage("Developer team name can not be more than 200 chars");
    }
  }
}