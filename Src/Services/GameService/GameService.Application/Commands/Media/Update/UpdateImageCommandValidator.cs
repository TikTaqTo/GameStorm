using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Media.Update {

  public class UpdateImageCommandValidator : AbstractValidator<UpdateImageCommand> {

    public UpdateImageCommandValidator() {
      //Необходимо реализовать
    }
  }
}