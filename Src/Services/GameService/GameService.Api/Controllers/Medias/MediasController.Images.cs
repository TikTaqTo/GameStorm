﻿using System;
using System.Threading.Tasks;
using GameService.Api.Model.Media;
using GameService.Api.Model.Replies;
using GameService.Application.Commands.Media.Create;
using GameService.Application.Queries.Media;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GameService.Api.Controllers.Medias {

  public partial class MediasController {

    [HttpPost("create-image")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ImageReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> CreateImage([FromBody] Image image) {
      var domainImage = _mapper.Map<Domain.EntityModels.Media.Image>(image);
      var createCountryCommand = new CreateImageCommand(domainImage);
      var cratedImageReply = await _mediator.Send(createCountryCommand);
      var mappedCratedImageReply = _mapper.Map<ImageReply>(cratedImageReply);
      return Ok(mappedCratedImageReply);
    }

    [HttpGet("retrieve-images")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ImagesReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveImages() {
      var query = new RetrieveImagesQuery();
      var imagesReply = await _mediator.Send(query);
      var mappedImagesReply = _mapper.Map<ImagesReply>(imagesReply);
      return Ok(mappedImagesReply);
    }
  }
}