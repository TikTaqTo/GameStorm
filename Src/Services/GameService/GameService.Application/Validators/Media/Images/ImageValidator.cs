using FluentValidation;
using GameService.Domain.EntityModels.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Validators.Media.Images {

  public class ImageValidator : AbstractValidator<Image> {

    public ImageValidator() {
      RuleFor(x => x.Name)
        .NotNull()
        .WithMessage("Image name can not be null")
        .NotEmpty()
        .WithMessage("Image name can not be empty")
        .MaximumLength(200)
        .WithMessage("Image name can not be more than 200 chars");
    }
  }
}