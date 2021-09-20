﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Tags.Delete {

  public class DeleteTagCommandValidator : AbstractValidator<DeleteTagCommand> {

    public DeleteTagCommandValidator() {
      RuleFor(x => x.Id)
        .GreaterThan(0)
        .WithMessage("Id can not be smaller than 0");
    }
  }
}