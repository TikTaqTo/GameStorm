using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Media.Delete {

  public class DeleteImageCommandValidator : AbstractValidator<DeleteImageCommand> {

    public DeleteImageCommandValidator() {
      //Необходимо дописать валидацию
    }
  }
}