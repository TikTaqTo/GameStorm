using GameService.Api.Model.Dictionaries;
using GameService.Api.Model.Replies;
using GameService.Application.Commands.Dictionaries.Genres.Create;
using GameService.Application.Commands.Dictionaries.Genres.Delete;
using GameService.Application.Commands.Dictionaries.Genres.Update;
using GameService.Application.Commands.Dictionaries.Tags.Create;
using GameService.Application.Commands.Dictionaries.Tags.Delete;
using GameService.Application.Commands.Dictionaries.Tags.Update;
using GameService.Application.Queries.Dictionaries.Genres;
using GameService.Application.Queries.Dictionaries.Tags;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameService.Api.Controllers.Dictionaries {

  public partial class TagsController : ControllerBase {
    #region Retrieve
    /// <summary>
    ///     Method to retrieve tags
    /// </summary>
    /// <param name="tag-retrieves"></param>
    /// <returns></returns>
    [HttpGet("retrieve-tags")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TagsReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveTags() {
      var query = new RetrieveTagsQuery();
      var tagsReply = await _mediator.Send(query);
      var mappedTagsReply = _mapper.Map<TagsReply>(tagsReply);
      return Ok(mappedTagsReply);
    }
    #endregion

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

    /// <summary>
    ///     Method to update tag
    /// </summary>
    /// <param name="tag-update"></param>
    /// <returns></returns>
    [HttpPost("update-tag")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TagReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> UpdateTag([FromBody] Tag tag) {
      var domainTag = _mapper.Map<Domain.EntityModels.Dictionaries.Tag>(tag);
      var updateTagCommand = new UpdateTagCommand(domainTag);
      var updatedTagReply = await _mediator.Send(updateTagCommand);
      var mappedUpdatedTagReply = _mapper.Map<TagReply>(updatedTagReply);
      return Ok(mappedUpdatedTagReply);
    }

    /// <summary>
    ///     Method to delete tag by id
    /// </summary>
    /// <param name="tag-delete"></param>
    /// <returns></returns>
    [HttpDelete("delete-tag-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TagReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> DeleteTag(int tagId) {
      var deleteTagReply = await _mediator.Send(new DeleteTagCommand(tagId));
      var mappedDeletedTagReply = _mapper.Map<TagReply>(deleteTagReply);
      return Ok(mappedDeletedTagReply);
    }
  }
}