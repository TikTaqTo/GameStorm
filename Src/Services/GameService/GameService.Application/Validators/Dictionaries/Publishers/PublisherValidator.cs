using FluentValidation;
using GameService.Domain.EntityModels.Dictionaries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Validators.Dictionaries.Publishers {

  public class PublisherValidator : AbstractValidator<Publisher> {

    public PublisherValidator() {
      RuleFor(x => x.Name)
        .NotNull()
        .WithMessage("Publisher name can not be null")
        .NotEmpty()
        .WithMessage("Publisher name can not be empty")
        .MaximumLength(200)
        .WithMessage("Publisher name can not be more than 200 chars");
    }
  }
}