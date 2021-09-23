using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserIdentityService.Application.Abstractions;
using UserIdentityService.Domain.Responses;

namespace UserIdentityService.Application.Commands.Security.Registration {
  public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, UserManagerResponse> {
    private readonly ISecurityService _securityService;

    public RegisterUserCommandHandler(ISecurityService securityService) {
      _securityService = securityService;
    }

    public async Task<UserManagerResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken) {
      return await _securityService.RegisterAsync(request.Request);
    }
  }
}
