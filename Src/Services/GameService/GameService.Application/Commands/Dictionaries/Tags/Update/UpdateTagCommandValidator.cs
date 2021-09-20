using FluentValidation;
using GameService.Application.Validators.Dictionaries.Tags;

namespace GameService.Application.Commands.Dictionaries.Tags.Update {

  public class UpdateTagCommandValidator : AbstractValidator<UpdatePublisherCommand> {

    public UpdateTagCommandValidator() {
      RuleFor(x => x.Tag)
               .SetValidator(new TagValidator())
               .WithMessage("Invalid tag entity");
    }
  }
}