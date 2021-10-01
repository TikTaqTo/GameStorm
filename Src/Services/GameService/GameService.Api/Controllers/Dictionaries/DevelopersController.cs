using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameService.Api.Controllers.Dictionaries {
  [ApiController]
  [Route("api/developers")]
  [Produces("application/json")]
  public partial class DevelopersController : ControllerBase {
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    /// <summary>
    ///
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="mapper"></param>
    public DevelopersController(IMediator mediator, IMapper mapper) {
      _mediator = mediator;
      _mapper = mapper;
    }
  }
}
