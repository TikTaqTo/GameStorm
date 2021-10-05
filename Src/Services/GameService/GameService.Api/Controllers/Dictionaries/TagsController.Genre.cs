using GameService.Api.Model.Dictionaries;
using GameService.Api.Model.Replies;
using GameService.Application.Commands.Dictionaries.Genres.Create;
using GameService.Application.Commands.Dictionaries.Genres.Delete;
using GameService.Application.Commands.Dictionaries.Genres.Update;
using GameService.Application.Commands.Dictionaries.Tags.Create;
using GameService.Application.Queries.Dictionaries.Genres;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameService.Api.Controllers.Dictionaries {

  public partial class TagsController : ControllerBase {
    
    /// <summary>
    ///     Method to create tag
    /// </summary>
    /// <param name="tag-create"></param>
    /// <returns></returns>
    [HttpPost("create-tag")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TagReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> CreateTag([FromBody] Tag tag) {
      var domainTag = _mapper.Map<Domain.EntityModels.Dictionaries.Tag>(tag);
      var createTagCommand = new CreateTagCommand(domainTag);
      var cratedTagReply = await _mediator.Send(createTagCommand);
      var mappedCratedtagReply = _mapper.Map<TagReply>(cratedTagReply);
      return Ok(mappedCratedtagReply);
    }
  }
}