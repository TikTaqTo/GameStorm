using FluentValidation;
using GameService.Domain.EntityModels.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Validators.Dictionaries.Tags {

  public class TagValidator : AbstractValidator<Tag> {

    public TagValidator() {
      RuleFor(x => x.Name)
        .NotNull()
        .WithMessage("Tag name can not be null")
        .NotEmpty()
        .WithMessage("Tag name can not be empty")
        .MaximumLength(200)
        .WithMessage("Tag name can not be more than 200 chars");
    }
  }
}