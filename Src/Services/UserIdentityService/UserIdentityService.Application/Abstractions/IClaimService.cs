using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserIdentityService.Domain.EntityModels.User;
using UserIdentityService.Domain.Responses;

namespace UserIdentityService.Application.Abstractions {
  public interface IClaimService {

    Task<UserManagerResponse> GetClaims(ApplicationUser user, params string[] roles);
  }
}
