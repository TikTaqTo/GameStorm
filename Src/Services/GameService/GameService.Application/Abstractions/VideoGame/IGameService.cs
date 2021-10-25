using GameService.Domain.EntityModels.VideoGame;
using GameService.Domain.Replies;
using GameService.Domain.Requests;
using System;
using System.Threading.Tasks;


namespace GameService.Application.Abstractions.VideoGame {

  public interface IGameService {

    Task<GameReply> CreateGame(Game game);

    Task<GameReply> UpdateGame(Game game);

    Task<GameReply> RetrieveGameById(Guid gameId);

    Task<GameReply> RetrieveGameByName(string gameTitle);

    Task<GamesReply> RetrieveGamesByName(string gameTitle);

    Task<GamesReply> RetrieveGames();

    Task<GamesReply> RetrieveGamesQueryPagination(int page, int pageSize);

    Task<GameReply> DeleteGameById(Guid id);

    Task<GameReply> AddGenreToGame(AddGenreToGameRequest request);

    Task<GameReply> AddTagToGame(AddTagToGameRequest request);

    Task<GameReply> AddDeveloperToGame(AddDeveloperToGameRequest request);

    Task<GameReply> AddPlatformToGame(AddPlatformToGameRequest request);

    Task<GameReply> AddPublisherToGame(AddPublisherToGameRequest request);

    Task<GameReply> AddScreenshotToGame(AddScreenshotToGameRequest request);
  }
}