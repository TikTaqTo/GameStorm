using GameService.Api.Model.Replies;
using GameService.Api.Model.Requests;
using GameService.Api.Model.VideoGame;
using GameService.Application.Commands.VideoGame.AddGenre;
using GameService.Application.Commands.VideoGame.Create;
using GameService.Application.Commands.VideoGame.Update;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameService.Api.Controllers.VideoGames {

  public partial class GamesController : ControllerBase {

    /// <summary>
    ///     Method to create game
    /// </summary>
    /// <param name="create"></param>
    /// <returns></returns>
    [HttpPost("create-game")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> CreateGame([FromBody] GameReply game) {
      var domainGame = _mapper.Map<Domain.EntityModels.VideoGame.Game>(game);
      var createGameCommand = new CreateGameCommand(domainGame);
      var cratedGameReply = await _mediator.Send(createGameCommand);
      var mappedCratedGameReply = _mapper.Map<GameReply>(cratedGameReply);
      return Ok(mappedCratedGameReply);
    }

    /// <summary>
    ///     Method to update game
    /// </summary>
    /// <param name="game-update"></param>
    /// <returns></returns>
    [HttpPost("update-game")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> UpdateGame([FromBody] Game game) {
      var domainGame = _mapper.Map<Domain.EntityModels.VideoGame.Game>(game);
      var updateGameCommand = new UpdateGameCommand(domainGame);
      var updatedGameReply = await _mediator.Send(updateGameCommand);
      var mappedUpdatedGameReply = _mapper.Map<GameReply>(updatedGameReply);
      return Ok(mappedUpdatedGameReply);
    }

    /// <summary>
    ///     Method to add genre to game
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("add-genre-to-game")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> AddGenreToMovie([FromBody] AddGenreToGameRequest request) {
      var domainRequest = _mapper.Map<Domain.Requests.AddGenreToGameRequest>(request);
      var query = new AddGenreToGameCommand(domainRequest);
      var gameReply = await _mediator.Send(query);
      var mappedGameReply = _mapper.Map<GameReply>(gameReply);
      return Ok(mappedGameReply);
    }
  }
}
