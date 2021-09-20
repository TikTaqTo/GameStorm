using FluentValidation;
using GameService.Application.Validators.Dictionaries.Platforms;

namespace GameService.Application.Commands.Dictionaries.Platforms.Update {

  public class CreatePlatformCommandValidator : AbstractValidator<UpdatePlatformCommand> {

    public UpdatePlatformCommandValidator() {
      RuleFor(x => x.Platform)
               .SetValidator(new PlatformValidator())
               .WithMessage("Invalid publisher entity");
    }
  }
}