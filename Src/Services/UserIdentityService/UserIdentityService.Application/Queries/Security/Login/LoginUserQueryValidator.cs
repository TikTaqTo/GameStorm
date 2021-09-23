using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserIdentityService.Application.Queries.Security.Login {
  public class LoginUserQueryValidator : AbstractValidator<LoginUserQuery> {

    public LoginUserQueryValidator() {
      RuleFor(x => x.Request.Email)
                .NotNull()
                .WithMessage("Email name can not be null")
                .NotEmpty()
                .WithMessage("Email name can not be empty")
                .MaximumLength(55)
                .WithMessage("Email name can not be more than 55 chars");
      RuleFor(x => x.Request.Password)
                .NotNull()
                .WithMessage("Password name can not be null")
                .NotEmpty()
                .WithMessage("Password name can not be empty")
                .MaximumLength(50)
                .WithMessage("Password name can not be more than 50 chars");
    }
  }
}
