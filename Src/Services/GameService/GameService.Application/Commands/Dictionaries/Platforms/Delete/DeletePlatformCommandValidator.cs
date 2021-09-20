using FluentValidation;
using GameService.Domain.Replies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Platforms.Delete {

  public class DeletePlatformCommandValidator : AbstractValidator<DeletePlatformCommand> {

    public DeletePlatformCommandValidator() {
      RuleFor(x => x.Id)
        .GreaterThan(0)
        .WithMessage("Id can not be smaller than 0");
    }
  }
}