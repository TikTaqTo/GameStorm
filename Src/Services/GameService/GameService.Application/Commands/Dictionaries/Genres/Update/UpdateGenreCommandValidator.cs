using FluentValidation;
using GameService.Application.Validators.Dictionaries.Genres;

namespace GameService.Application.Commands.Dictionaries.Genres.Update {

  public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand> {

    public UpdateGenreCommandValidator() {
      RuleFor(x => x.Genre)
               .SetValidator(new GenreValidator())
               .WithMessage("Invalid genre entity");
    }
  }
}