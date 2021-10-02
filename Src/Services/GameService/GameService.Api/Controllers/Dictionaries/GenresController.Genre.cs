using GameService.Api.Model.Dictionaries;
using GameService.Api.Model.Replies;
using GameService.Application.Commands.Dictionaries.Genres.Create;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameService.Api.Controllers.Dictionaries {

  public partial class GenresController : ControllerBase {

    /// <summary>
    ///     Method to create genre
    /// </summary>
    /// <param name="genre-create"></param>
    /// <returns></returns>
    [HttpPost("create-genre")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenreReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> CreateGenre([FromBody] Genre genre) {
      var domainGenre = _mapper.Map<Domain.EntityModels.Dictionaries.Genre>(genre);
      var createGenreCommand = new CreateGenreCommand(domainGenre);
      var cratedGenreReply = await _mediator.Send(createGenreCommand);
      var mappedCratedgenreReply = _mapper.Map<GenreReply>(cratedGenreReply);
      return Ok(mappedCratedgenreReply);
    }
  }
}