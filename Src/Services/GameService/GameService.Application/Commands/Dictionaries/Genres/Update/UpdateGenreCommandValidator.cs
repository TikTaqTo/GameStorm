using FluentValidation;
using GameService.Application.Validators.Dictionaries.Genres;

namespace GameService.Application.Commands.Dictionaries.Genres.Update {

  public class UpdateTagCommandValidator : AbstractValidator<UpdateTagCommand> {

    public UpdateTagCommandValidator() {
      RuleFor(x => x.Genre)
               .SetValidator(new GenreValidator())
               .WithMessage("Invalid genre entity");
    }
  }
}