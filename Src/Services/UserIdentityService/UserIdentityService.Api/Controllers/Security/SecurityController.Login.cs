using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserIdentityService.Api.Models.Requests;
using UserIdentityService.Api.Models.Responses;
using UserIdentityService.Application.Queries.Security.Login;

namespace UserIdentityService.Api.Controllers.Security {

  public partial class SecurityController {

    /// <summary>
    ///     Method to login
    /// </summary>
    /// <param name="login"></param>
    /// <returns></returns>
    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserManagerResponse))]
    public async Task<IActionResult> Login([FromBody] LoginRequest login) {
      var domainRequest = _mapper.Map<Domain.Requests.LoginRequest>(login);
      var loginUserQuery = new LoginUserQuery(domainRequest);
      var domainResponse = await _mediator.Send(loginUserQuery);
      var mappedResponse = _mapper.Map<UserManagerResponse>(domainResponse);
      return Ok(mappedResponse);
    }
  }
}