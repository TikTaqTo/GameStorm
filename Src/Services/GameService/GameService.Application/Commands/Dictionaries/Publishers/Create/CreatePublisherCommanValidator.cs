using FluentValidation;
using GameService.Application.Validators.Dictionaries.Publishers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Publishers.Create {

  public class CreatePublisherCommanValidator : AbstractValidator<CreatePublisherCommand> {

    public CreatePublisherCommanValidator() {
      RuleFor(x => x.Publisher)
        .SetValidator(new PublisherValidator())
        .WithMessage("Invalid publisher entity");
    }
  }
}