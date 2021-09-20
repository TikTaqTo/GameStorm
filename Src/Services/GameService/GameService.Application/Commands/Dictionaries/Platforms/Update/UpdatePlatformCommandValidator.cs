using FluentValidation;
using GameService.Application.Validators.Dictionaries.Platforms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Platforms.Update {

  public class UpdatePlatformCommandValidator : AbstractValidator<UpdatePlatformCommand> {

    public UpdatePlatformCommandValidator() {
      RuleFor(x => x.Platform)
               .SetValidator(new PlatformValidator())
               .WithMessage("Invalid platform entity");
    }
  }
}