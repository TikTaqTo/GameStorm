using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserIdentityService.Domain.Requests;

namespace UserIdentityService.Application.Validators.Security.Register {
  public class RegisterRequestValidator : AbstractValidator<RegisterRequest> {

    public RegisterRequestValidator() {
      RuleFor(x => x.Email)
                .NotNull()
                .WithMessage("Email name can not be null")
                .NotEmpty()
                .WithMessage("Email name can not be empty")
                .MaximumLength(55)
                .WithMessage("Email name can not be more than 55 chars");
      RuleFor(x => x.Password)
                .NotNull()
                .WithMessage("Password name can not be null")
                .NotEmpty()
                .WithMessage("Password name can not be empty")
                .MaximumLength(50)
                .WithMessage("Password name can not be more than 50 chars");
      RuleFor(x => x.ConfirmPassword)
               .NotNull()
               .WithMessage("ConfirmPassword name can not be null")
               .NotEmpty()
               .WithMessage("ConfirmPassword name can not be empty")
               .MaximumLength(50)
               .WithMessage("ConfirmPassword name can not be more than 50 chars");
      RuleFor(x => x.Role)
        .NotNull()
        .WithMessage("Role name can not be null")
        .NotEmpty()
        .WithMessage("Role name can not be empty")
        .MaximumLength(20)
        .WithMessage("Role name can not be more than 20 chars");
    }
  }
}
