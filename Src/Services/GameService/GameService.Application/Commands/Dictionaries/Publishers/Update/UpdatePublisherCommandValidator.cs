using FluentValidation;
using GameService.Application.Commands.Dictionaries.Publishers.Update;
using GameService.Application.Validators.Dictionaries.Platforms;
using GameService.Application.Validators.Dictionaries.Publishers;

namespace GameService.Application.Commands.Dictionaries.Platforms.Update {

  public class UpdatePublisherCommandValidator : AbstractValidator<UpdatePublisherCommand> {

    public UpdatePublisherCommandValidator() {
      RuleFor(x => x.Publisher)
               .SetValidator(new PublisherValidator())
               .WithMessage("Invalid publisher entity");
    }
  }
}