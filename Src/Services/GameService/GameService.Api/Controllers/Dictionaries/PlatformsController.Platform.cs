using GameService.Api.Model.Dictionaries;
using GameService.Api.Model.Replies;
using GameService.Application.Commands.Dictionaries.Genres.Create;
using GameService.Application.Commands.Dictionaries.Genres.Delete;
using GameService.Application.Commands.Dictionaries.Genres.Update;
using GameService.Application.Commands.Dictionaries.Platforms.Create;
using GameService.Application.Commands.Dictionaries.Platforms.Delete;
using GameService.Application.Commands.Dictionaries.Platforms.Update;
using GameService.Application.Commands.Dictionaries.Tags.Create;
using GameService.Application.Commands.Dictionaries.Tags.Delete;
using GameService.Application.Commands.Dictionaries.Tags.Update;
using GameService.Application.Queries.Dictionaries.Genres;
using GameService.Application.Queries.Dictionaries.Tags;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameService.Api.Controllers.Dictionaries {

  public partial class PlatformsController : ControllerBase {
    
    /// <summary>
    ///     Method to create platform
    /// </summary>
    /// <param name="platform-create"></param>
    /// <returns></returns>
    [HttpPost("create-platform")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlatformReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> CreatePlatform([FromBody] Platform platform) {
      var domainPlatform = _mapper.Map<Domain.EntityModels.Dictionaries.Platform>(platform);
      var createPlatformCommand = new CreatePlatformCommand(domainPlatform);
      var cratedPlatformReply = await _mediator.Send(createPlatformCommand);
      var mappedCratedplatformReply = _mapper.Map<PlatformReply>(cratedPlatformReply);
      return Ok(mappedCratedplatformReply);
    }

    /// <summary>
    ///     Method to update platform
    /// </summary>
    /// <param name="platform-update"></param>
    /// <returns></returns>
    [HttpPost("update-platform")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlatformReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> UpdatePlatform([FromBody] Platform platform) {
      var domainPlatform = _mapper.Map<Domain.EntityModels.Dictionaries.Platform>(platform);
      var updatePlatformCommand = new UpdatePlatformCommand(domainPlatform);
      var updatedPlatformReply = await _mediator.Send(updatePlatformCommand);
      var mappedUpdatedPlatformReply = _mapper.Map<PlatformReply>(updatedPlatformReply);
      return Ok(mappedUpdatedPlatformReply);
    }

    /// <summary>
    ///     Method to delete platform by id
    /// </summary>
    /// <param name="platform-delete"></param>
    /// <returns></returns>
    [HttpDelete("delete-platform-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PlatformReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> DeletePlatform(int platformId) {
      var deletePlatformReply = await _mediator.Send(new DeletePlatformCommand(platformId));
      var mappedDeletedPlatformReply = _mapper.Map<PlatformReply>(deletePlatformReply);
      return Ok(mappedDeletedPlatformReply);
    }
  }
}