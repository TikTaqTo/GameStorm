using FluentValidation;
using GameService.Application.Validators.Dictionaries.Developers;

namespace GameService.Application.Commands.Dictionaries.Developers.Update {

  public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand> {

    public UpdateGenreCommandValidator() {
      RuleFor(x => x.Developer)
               .SetValidator(new DeveloperValidator())
               .WithMessage("Invalid genre entity");
    }
  }
}