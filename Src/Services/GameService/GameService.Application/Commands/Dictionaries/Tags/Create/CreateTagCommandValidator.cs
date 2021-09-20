using FluentValidation;
using GameService.Application.Validators.Dictionaries.Tags;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Tags.Create {

  public class CreateTagCommandValidator : AbstractValidator<CreateTagCommand> {

    public CreateTagCommandValidator() {
      RuleFor(x => x.Tag)
        .SetValidator(new TagValidator())
        .WithMessage("Invalid tag entity");
    }
  }
}