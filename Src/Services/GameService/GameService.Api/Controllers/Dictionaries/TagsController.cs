using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameService.Api.Controllers.Dictionaries {
  [ApiController]
  [Route("api/genres")]
  [Produces("application/json")]
  public partial class TagsController : ControllerBase {
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    /// <summary>
    ///
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="mapper"></param>
    public TagsController(IMediator mediator, IMapper mapper) {
      _mediator = mediator;
      _mapper = mapper;
    }
  }
}
