﻿using GameService.Api.Model.Dictionaries;
using GameService.Api.Model.Replies;
using GameService.Application.Commands.Dictionaries.Genres.Create;
using GameService.Application.Commands.Dictionaries.Genres.Delete;
using GameService.Application.Commands.Dictionaries.Genres.Update;
using GameService.Application.Commands.Dictionaries.Publishers.Create;
using GameService.Application.Commands.Dictionaries.Publishers.Update;
using GameService.Application.Queries.Dictionaries.Genres;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GameService.Api.Controllers.Dictionaries {

  public partial class PublishersController : ControllerBase {
    #region Retrieve
   
    #endregion

    /// <summary>
    ///     Method to create publisher
    /// </summary>
    /// <param name="publisher-create"></param>
    /// <returns></returns>
    [HttpPost("create-publisher")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublisherReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> CreatePublisher([FromBody] Publisher publisher) {
      var domainPublisher = _mapper.Map<Domain.EntityModels.Dictionaries.Publisher>(publisher);
      var createPublisherCommand = new CreatePublisherCommand(domainPublisher);
      var cratedPublisherReply = await _mediator.Send(createPublisherCommand);
      var mappedCratedpublisherReply = _mapper.Map<PublisherReply>(cratedPublisherReply);
      return Ok(mappedCratedpublisherReply);
    }

    /// <summary>
    ///     Method to update publisher
    /// </summary>
    /// <param name="publisher-update"></param>
    /// <returns></returns>
    [HttpPost("update-publisher")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PublisherReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> UpdatePublisher([FromBody] Publisher publisher) {
      var domainPublisher = _mapper.Map<Domain.EntityModels.Dictionaries.Publisher>(publisher);
      var updatePublisherCommand = new UpdatePublisherCommand(domainPublisher);
      var updatedPublisherReply = await _mediator.Send(updatePublisherCommand);
      var mappedUpdatedPublisherReply = _mapper.Map<PublisherReply>(updatedPublisherReply);
      return Ok(mappedUpdatedPublisherReply);
    }
  }
}