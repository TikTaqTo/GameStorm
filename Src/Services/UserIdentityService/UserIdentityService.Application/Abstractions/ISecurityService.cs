using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserIdentityService.Domain.Requests;
using UserIdentityService.Domain.Responses;

namespace UserIdentityService.Application.Abstractions {
  public interface ISecurityService {

    Task<UserManagerResponse> RegisterAsync(RegisterRequest request);

    Task<UserManagerResponse> LoginAsync(LoginRequest request);
  }
}
