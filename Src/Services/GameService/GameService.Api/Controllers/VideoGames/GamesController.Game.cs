using GameService.Api.Model.Replies;
using GameService.Api.Model.Requests;
using GameService.Api.Model.VideoGame;
using GameService.Application.Commands.VideoGame.AddDeveloper;
using GameService.Application.Commands.VideoGame.AddGenre;
using GameService.Application.Commands.VideoGame.AddPlatform;
using GameService.Application.Commands.VideoGame.AddPublisher;
using GameService.Application.Commands.VideoGame.AddScreenshot;
using GameService.Application.Commands.VideoGame.AddTag;
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

    /// <summary>
    ///     Method to retrieve games by name
    /// </summary>
    /// <param name="retrieve-games-by-name"></param>
    /// <returns></returns>
    [HttpGet("retrieve-games-by-name")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GamesReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveGamesByName(string gameName) {
      var query = new RetrieveGamesByNameQuery(gameName);
      var gamesReply = await _mediator.Send(query);
      var mappedGamesReply = _mapper.Map<GamesReply>(gamesReply);
      return Ok(mappedGamesReply);
    }

    /// <summary>
    ///     Method to retrieve games for pagination
    /// </summary>
    /// <param name="retrieve-games-pagination"></param>
    /// <param name="page"></param>
    /// <param name="pageSize"</param>
    /// <returns></returns>
    [HttpGet("retrieve-games-pagination")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GamesReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveGamesPagination(int page, int pageSize) {
      var query = new RetrieveGamesQueryPagination(page, pageSize);
      var gamesReply = await _mediator.Send(query);
      var mappedGamesReply = _mapper.Map<GamesReply>(gamesReply);
      return Ok(mappedGamesReply);
    }

    /// <summary>
    ///     Method to retrieve games by tag
    /// </summary>
    /// <param name="retrieve-games-by-tag"></param>
    /// <param name="tag"></param>
    /// <returns></returns>
    [HttpGet("retrieve-games-by-tag")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GamesReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveGamesByTag(string tag) {
      var query = new RetrieveGamesByTagQuery(tag);
      var gamesReply = await _mediator.Send(query);
      var mappedGamesReply = _mapper.Map<GamesReply>(gamesReply);
      return Ok(mappedGamesReply);
    }

    /// <summary>
    ///     Method to retrieve games by genre
    /// </summary>
    /// <param name="retrieve-games-by-genre"></param>
    /// <param name="genre"></param>
    /// <returns></returns>
    [HttpGet("retrieve-games-by-genre")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GamesReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveGamesByGenre(string genre) {
      var query = new RetrieveGamesByGenreQuery(genre);
      var gamesReply = await _mediator.Send(query);
      var mappedGamesReply = _mapper.Map<GamesReply>(gamesReply);
      return Ok(mappedGamesReply);
    }

    /// <summary>
    ///     Method to retrieve games by platform
    /// </summary>
    /// <param name="retrieve-games-by-platform"></param>
    /// <param name="platform"></param>
    /// <returns></returns>
    [HttpGet("retrieve-games-by-platform")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GamesReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveGamesByPlatform(string platform) {
      var query = new RetrieveGamesByPlatformQuery(platform);
      var gamesReply = await _mediator.Send(query);
      var mappedGamesReply = _mapper.Map<GamesReply>(gamesReply);
      return Ok(mappedGamesReply);
    }

    /// <summary>
    ///     Method to retrieve games by publisher
    /// </summary>
    /// <param name="retrieve-games-by-publisher"></param>
    /// <param name="publisher"></param>
    /// <returns></returns>
    [HttpGet("retrieve-games-by-publisher")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GamesReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveGamesByPublisher(string publisher) {
      var query = new RetrieveGamesByPublisherQuery(publisher);
      var gamesReply = await _mediator.Send(query);
      var mappedGamesReply = _mapper.Map<GamesReply>(gamesReply);
      return Ok(mappedGamesReply);
    }

    /// <summary>
    ///     Method to retrieve games by developer
    /// </summary>
    /// <param name="retrieve-games-by-developer"></param>
    /// <param name="developer"></param>
    /// <returns></returns>
    [HttpGet("retrieve-games-by-developer")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GamesReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> RetrieveGamesByDeveloper(string developer) {
      var query = new RetrieveGamesByDeveloperQuery(developer);
      var gamesReply = await _mediator.Send(query);
      var mappedGamesReply = _mapper.Map<GamesReply>(gamesReply);
      return Ok(mappedGamesReply);
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

    /// <summary>
    ///     Method to add tag to game
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("add-tag-to-game")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> AddTagToGame([FromBody] AddTagToGameRequest request) {
      var domainRequest = _mapper.Map<Domain.Requests.AddTagToGameRequest>(request);
      var query = new AddTagToGameCommand(domainRequest);
      var gameReply = await _mediator.Send(query);
      var mappedGameReply = _mapper.Map<GameReply>(gameReply);
      return Ok(mappedGameReply);
    }

    /// <summary>
    ///     Method to add developer to game
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("add-developer-to-game")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> AddDeveloperToGame([FromBody] AddDeveloperToGameRequest request) {
      var domainRequest = _mapper.Map<Domain.Requests.AddDeveloperToGameRequest>(request);
      var query = new AddDeveloperToGameCommand(domainRequest);
      var gameReply = await _mediator.Send(query);
      var mappedGameReply = _mapper.Map<GameReply>(gameReply);
      return Ok(mappedGameReply);
    }

    /// <summary>
    ///     Method to add platform to game
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("add-platform-to-game")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> AddPlatformToGame([FromBody] AddPlatformToGameRequest request) {
      var domainRequest = _mapper.Map<Domain.Requests.AddPlatformToGameRequest>(request);
      var query = new AddPlatformToGameCommand(domainRequest);
      var gameReply = await _mediator.Send(query);
      var mappedGameReply = _mapper.Map<GameReply>(gameReply);
      return Ok(mappedGameReply);
    }

    /// <summary>
    ///     Method to add publisher to game
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("add-publisher-to-game")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> AddPublisherToGame([FromBody] AddPublisherToGameRequest request) {
      var domainRequest = _mapper.Map<Domain.Requests.AddPublisherToGameRequest>(request);
      var query = new AddPublisherToGameCommand(domainRequest);
      var gameReply = await _mediator.Send(query);
      var mappedGameReply = _mapper.Map<GameReply>(gameReply);
      return Ok(mappedGameReply);
    }

    /// <summary>
    ///     Method to add screenshot to game
    /// </summary>
    /// <param name="request"></param>
    /// <returns></returns>
    [HttpPost("add-screenshot-to-game")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GameReply))]
    [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(CommonReply))]
    [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(CommonReply))]
    public async Task<IActionResult> AddScreenshotToGame([FromBody] AddScreenshotToGameRequest request) {
      var domainRequest = _mapper.Map<Domain.Requests.AddScreenshotToGameRequest>(request);
      var query = new AddScreenshotToGameCommand(domainRequest);
      var gameReply = await _mediator.Send(query);
      var mappedGameReply = _mapper.Map<GameReply>(gameReply);
      return Ok(mappedGameReply);
    }
  }
}
