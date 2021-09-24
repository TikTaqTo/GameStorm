using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserIdentityService.Api.Models.Requests;
using UserIdentityService.Api.Models.Responses;
using UserIdentityService.Application.Commands.Security.Registration;

namespace UserIdentityService.Api.Controllers.Security {

  public partial class SecurityController {

    /// <summary>
    ///     Method to register
    /// </summary>
    /// <param name="register"></param>
    /// <returns></returns>
    [HttpPost("register")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(UserManagerResponse))]
    public async Task<IActionResult> Register([FromBody] RegisterRequest register) {
      var domainRequest = _mapper.Map<Domain.Requests.RegisterRequest>(register);
      var registerUserCommand = new RegisterUserCommand(domainRequest);
      var domainResponse = await _mediator.Send(registerUserCommand);
      var mappedResponse = _mapper.Map<UserManagerResponse>(domainResponse);
      return Ok(mappedResponse);
    }
  }
}