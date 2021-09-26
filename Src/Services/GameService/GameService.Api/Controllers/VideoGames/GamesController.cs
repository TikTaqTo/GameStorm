using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameService.Api.Controllers.VideoGames {
  [ApiController]
  [Route("api/movies")]
  [Produces("application/json")]
  public partial class GamesController : ControllerBase {
    private readonly IMapper _mapper;
    private readonly IMediator _mediator;

    /// <summary>
    ///
    /// </summary>
    /// <param name="mediator"></param>
    /// <param name="mapper"></param>
    public GamesController(IMediator mediator, IMapper mapper) {
      _mediator = mediator;
      _mapper = mapper;
    }
  }
}
