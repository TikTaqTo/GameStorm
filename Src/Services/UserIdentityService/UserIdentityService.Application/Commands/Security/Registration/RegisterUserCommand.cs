using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserIdentityService.Domain.Requests;
using UserIdentityService.Domain.Responses;

namespace UserIdentityService.Application.Commands.Security.Registration {
  public class RegisterUserCommand : IRequest<UserManagerResponse> {

    public RegisterUserCommand(RegisterRequest request) {
      Request = request;
    }

    public RegisterRequest Request { get; }
  }
}
