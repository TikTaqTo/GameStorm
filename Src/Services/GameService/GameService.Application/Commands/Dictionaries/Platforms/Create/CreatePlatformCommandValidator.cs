using FluentValidation;
using GameService.Application.Validators.Dictionaries.Platforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Platforms.Create {

  public class CreatePlatformCommandValidator : AbstractValidator<CreatePlatformCommand> {

    public CreatePlatformCommandValidator() {
      RuleFor(x => x.Platform)
        .SetValidator(new PlatformValidator())
        .WithMessage("Invalid platform entity");
    }
  }
}