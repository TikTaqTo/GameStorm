using FluentValidation;
using GameService.Domain.EntityModels.Dictionaries;

namespace GameService.Application.Validators.Dictionaries.Platforms {

  public class PlatformValidator : AbstractValidator<Domain.EntityModels.Dictionaries.Platform> {

    public PlatformValidator() {
      RuleFor(x => x.Name)
        .NotNull()
        .WithMessage("Platform name can not be null")
        .NotEmpty()
        .WithMessage("Platform name can not be empty")
        .MaximumLength(200)
        .WithMessage("Platform name can not be more than 200 chars");
    }
  }
}