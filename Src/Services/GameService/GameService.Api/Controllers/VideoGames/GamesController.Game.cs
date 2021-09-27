using GameService.Api.Model.Replies;
using GameService.Api.Model.Requests;
using GameService.Api.Model.VideoGame;
using GameService.Application.Commands.VideoGame.AddGenre;
using GameService.Application.Commands.VideoGame.Create;
using GameService.Application.Commands.VideoGame.Delete;
using GameService.Application.Commands.VideoGame.Update;
using GameService.Application.Queries.VideoGame;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameService.Api.Controllers.VideoGames {

  public partial class GamesController : ControllerBase {
    #region Retrieve
    /// <summary>
    ///     Method to retrieve games
    /// </summary>
    /// <param name="game-retrieves"></param>
    /// <returns></returns>
    [HttpGet("retrieve-games")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GamesReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveGames() {
      var query = new RetrieveGamesQuery();
      var gamesReply = await _mediator.Send(query);
      var mappedGamesReply = _mapper.Map<GamesReply>(gamesReply);
      return Ok(mappedGamesReply);
    }

    /// <summary>
    ///     Method to retrieve game by id
    /// </summary>
    /// <param name="game-retrieve-by-id"></param>
    /// <returns></returns>
    [HttpGet("retrieve-game-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveGameById(Guid gameId) {
      var query = new RetrieveGameByIdQuery(gameId);
      var gameReply = await _mediator.Send(query);
      var mappedGameReply = _mapper.Map<GameReply>(gameReply);
      return Ok(mappedGameReply);
    }

    /// <summary>
    ///     Method to retrieve game by name
    /// </summary>
    /// <param name="retrieve-game-by-name"></param>
    /// <returns></returns>
    [HttpGet("retrieve-game-by-name")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveGameByName(string gameName) {
      var query = new RetrieveGameByNameQuery(gameName);
      var gameReply = await _mediator.Send(query);
      var mappedGameReply = _mapper.Map<GameReply>(gameReply);
      return Ok(mappedGameReply);
    }
    #endregion


    /// <summary>
    ///     Method to create game
    /// </summary>
    /// <param name="game-create"></param>
    /// <returns></returns>
    [HttpPost("create-game")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> CreateGame([FromBody] Game game) {
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
    ///     Method to delete game by id
    /// </summary>
    /// <param name="game-delete"></param>
    /// <returns></returns>
    [HttpDelete("delete-game-by-id")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> DeleteGame(Guid gameId) {
      var deleteGameReply = await _mediator.Send(new DeleteGameCommand(gameId));
      var mappedDeletedGameReply = _mapper.Map<GameReply>(deleteGameReply);
      return Ok(mappedDeletedGameReply);
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
    public async Task<IActionResult> AddGenreToGame([FromBody] AddGenreToGameRequest request) {
      var domainRequest = _mapper.Map<Domain.Requests.AddGenreToGameRequest>(request);
      var query = new AddGenreToGameCommand(domainRequest);
      var gameReply = await _mediator.Send(query);
      var mappedGameReply = _mapper.Map<GameReply>(gameReply);
      return Ok(mappedGameReply);
    }
  }
}
