using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace UserIdentityService.Api.Controllers.Security {

  [Route("api/security")]
  [ApiController]
  [Produces("application/json")]
  public partial class SecurityController : Controller {
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    /// <summary>
    ///
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="mapper"></param>
    public SecurityController(IMediator mediator, IMapper mapper) {
      _mediator = mediator;
      _mapper = mapper;
    }
  }
}