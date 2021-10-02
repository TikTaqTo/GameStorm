using FluentValidation;
using GameService.Application.Validators.Dictionaries.Developers;

namespace GameService.Application.Commands.Dictionaries.Developers.Update {

  public class UpdateDeveloperCommandValidator : AbstractValidator<UpdateDeveloperCommand> {

    public UpdateDeveloperCommandValidator() {
      RuleFor(x => x.Developer)
               .SetValidator(new DeveloperValidator())
               .WithMessage("Invalid developer entity");
    }
  }
}