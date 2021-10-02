using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using GameService.Api.Model.Replies;
using GameService.Api.Model.Dictionaries;
using GameService.Application.Commands.Dictionaries.Developers.Create;
using GameService.Application.Commands.Dictionaries.Developers.Delete;


namespace GameService.Api.Controllers.Dictionaries {

  public partial class DevelopersController : ControllerBase {
    #region Retrieve
    
    #endregion


    /// <summary>
    ///     Method to create developer
    /// </summary>
    /// <param name="developer-create"></param>
    /// <returns></returns>
    [HttpPost("create-developer")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeveloperReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> CreateDeveloper([FromBody] Developer developer) {
      var domainDeveloper = _mapper.Map<Domain.EntityModels.Dictionaries.Developer>(developer);
      var createDeveloperCommand = new CreateDeveloperCommand(domainDeveloper);
      var cratedDeveloperReply = await _mediator.Send(createDeveloperCommand);
      var mappedCrateddeveloperReply = _mapper.Map<DeveloperReply>(cratedDeveloperReply);
      return Ok(mappedCrateddeveloperReply);
    }

    /// <summary>
    ///     Method to delete developer by id
    /// </summary>
    /// <param name="developer-delete"></param>
    /// <returns></returns>
    [HttpDelete("delete-developer-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(DeveloperReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> DeleteDeveloper(int developerId) {
      var deleteDeveloperReply = await _mediator.Send(new DeleteDeveloperCommand(developerId));
      var mappedDeletedDeveloperReply = _mapper.Map<DeveloperReply>(deleteDeveloperReply);
      return Ok(mappedDeletedDeveloperReply);
    }
  }
}
