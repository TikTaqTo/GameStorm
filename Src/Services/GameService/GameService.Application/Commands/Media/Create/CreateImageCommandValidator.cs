using FluentValidation;
using GameService.Application.Validators.Media.Images;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Media.Create {

  public class CreateImageCommandValidator : AbstractValidator<CreateImageCommand> {

    public CreateImageCommandValidator() {
      RuleFor(x => x.Image)
        .SetValidator(new ImageValidator())
        .WithMessage("Invalid image entity");
    }
  }
}