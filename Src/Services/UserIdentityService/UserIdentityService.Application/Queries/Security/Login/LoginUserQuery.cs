using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserIdentityService.Domain.Requests;
using UserIdentityService.Domain.Responses;

namespace UserIdentityService.Application.Queries.Security.Login {
  public class LoginUserQuery : IRequest<UserManagerResponse> {

    public LoginUserQuery(LoginRequest request) {
      Request = request;
    }

    public LoginRequest Request { get; }
  }
}
