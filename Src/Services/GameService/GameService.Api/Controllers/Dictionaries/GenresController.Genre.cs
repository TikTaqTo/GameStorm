using GameService.Api.Model.Dictionaries;
using GameService.Api.Model.Replies;
using GameService.Application.Commands.Dictionaries.Genres.Create;
using GameService.Application.Commands.Dictionaries.Genres.Delete;
using GameService.Application.Commands.Dictionaries.Genres.Update;
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

    /// <summary>
    ///     Method to update genre
    /// </summary>
    /// <param name="genre-update"></param>
    /// <returns></returns>
    [HttpPost("update-genre")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenreReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> UpdateGenre([FromBody] Genre genre) {
      var domainGenre = _mapper.Map<Domain.EntityModels.Dictionaries.Genre>(genre);
      var updateGenreCommand = new UpdateGenreCommand(domainGenre);
      var updatedGenreReply = await _mediator.Send(updateGenreCommand);
      var mappedUpdatedGenreReply = _mapper.Map<GenreReply>(updatedGenreReply);
      return Ok(mappedUpdatedGenreReply);
    }

    /// <summary>
    ///     Method to delete genre by id
    /// </summary>
    /// <param name="genre-delete"></param>
    /// <returns></returns>
    [HttpDelete("delete-genre-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GenreReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> DeleteGenre(int genreId) {
      var deleteGenreReply = await _mediator.Send(new DeleteGenreCommand(genreId));
      var mappedDeletedGenreReply = _mapper.Map<GenreReply>(deleteGenreReply);
      return Ok(mappedDeletedGenreReply);
    }
  }
}