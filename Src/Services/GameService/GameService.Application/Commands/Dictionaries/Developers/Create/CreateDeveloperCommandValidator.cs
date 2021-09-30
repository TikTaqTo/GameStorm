using FluentValidation;
using GameService.Application.Validators.Dictionaries.Developers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Developers.Create {

  public class CreateDeveloperCommandValidator : AbstractValidator<CreateDeveloperCommand> {

    public CreateDeveloperCommandValidator() {
      RuleFor(x => x.Developer)
                .SetValidator(new DeveloperValidator())
                .WithMessage("Invalid developers team entity");
    }
  }
}