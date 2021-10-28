using GameService.Application.Abstractions.VideoGame;
using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.EntityModels.VideoGame;
using GameService.Domain.Replies;
using GameService.Domain.Requests;
using GameService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace GameService.Infrastructure.Services.VideoGame {

  public class GamesService : IGameService {
    private readonly GameServiceContext _context;

    public GamesService(GameServiceContext context) {
      _context = context;
    }

    public async Task<GameReply> CreateGame(Game game) {
      await _context.Games.AddAsync(game);
      await _context.SaveChangesAsync();
      return new GameReply() {
        Game = game
      };
    }

    public async Task<GameReply> DeleteGameById(Guid id) {
      var game = _context.Games.Find(id);
      game.DeletedAt = DateTimeOffset.Now;
      game.DeletedBy = "admin";
      game.DeletedReason = "delete info";
      await _context.SaveChangesAsync();
      return new GameReply {
        Game = game
      };
    }

    public async Task<GamesReply> RetrieveGames() {
      var allGames = _context.Games
        .Include(x => x.Platforms)
        .Include(x => x.Genres)
        .Include(x => x.Developers)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags);

      var gamesReply = new GamesReply() {
        Games = allGames
      };

      return await Task.FromResult(gamesReply);
    }

    public async Task<GameReply> UpdateGame(Game game) {
      //Проверить как он копирует IEnumerable<Genre> и т.д
      _context.Games.Update(game);
      await _context.SaveChangesAsync();
      return new GameReply() {
        Game = game
      };
    }

    public async Task<GameReply> RetrieveGameById(Guid gameId) {
      var game = _context.Games.Where(x => x.Id == gameId)
        .Include(x => x.Platforms)
        .Include(x => x.Genres)
        .Include(x => x.Developers)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags)
        .First();

      var gameReply = new GameReply() {
        Game = game
      };

      return await Task.FromResult(gameReply);
    }

    public async Task<GameReply> RetrieveGameByName(string gameTitle) {
      var game = _context.Games.Where(x => x.Title == gameTitle)
        .Include(x => x.Platforms)
        .Include(x => x.Genres)
        .Include(x => x.Developers)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags)
        .First();

      var gameReply = new GameReply() {
        Game = game
      };

      return await Task.FromResult(gameReply);
    }

    public async Task<GamesReply> RetrieveGamesByName(string gameTitle) {
      var games = _context.Games.Where(x => x.Title.Contains(gameTitle))
        .Include(x => x.Platforms)
        .Include(x => x.Genres)
        .Include(x => x.Developers)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags);

      var gamesReply = new GamesReply() {
        Games = games
      };

      return await Task.FromResult(gamesReply);
    }

    public async Task<GamesReply> RetrieveGamesByTag(string tag) {
      string normalizedTag = tag.ToLower();

      var games = _context.Games
        .Include(x => x.Platforms)
        .Include(x => x.Genres)
        .Include(x => x.Developers)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags)
        .Where(x => x.Tags.Any(t => t.NormalizedName == normalizedTag));

      var gamesReply = new GamesReply() {
        Games = games
      };

      return await Task.FromResult(gamesReply);
    }

    public async Task<GamesReply> RetrieveGamesByGenre(string genre) {
      string normalizedGenre = genre.ToLower();

      var games = _context.Games
        .Include(x => x.Platforms)
        .Include(x => x.Genres)
        .Include(x => x.Developers)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags)
        .Where(x => x.Genres.Any(t => t.NormalizedName == normalizedGenre));

      var gamesReply = new GamesReply() {
        Games = games
      };

      return await Task.FromResult(gamesReply);
    }

    public async Task<GamesReply> RetrieveGamesByPlatform(string platform) {
      string normalizedPlatform = platform.ToLower();

      var games = _context.Games
        .Include(x => x.Platforms)
        .Include(x => x.Genres)
        .Include(x => x.Developers)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags)
        .Where(x => x.Platforms.Any(t => t.NormalizedName == normalizedPlatform));

      var gamesReply = new GamesReply() {
        Games = games
      };

      return await Task.FromResult(gamesReply);
    }

    public async Task<GamesReply> RetrieveGamesByPublisher(string publisher) {
      string normalizedPublisher = publisher.ToLower();

      var games = _context.Games
        .Include(x => x.Platforms)
        .Include(x => x.Genres)
        .Include(x => x.Developers)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags)
        .Where(x => x.Publishers.Any(t => t.NormalizedName == normalizedPublisher));

      var gamesReply = new GamesReply() {
        Games = games
      };

      return await Task.FromResult(gamesReply);
    }

    public async Task<GamesReply> RetrieveGamesQueryPagination(int page, int pageSize) {
      var games = _context.Games
        .Skip(page * pageSize)
        .Take(pageSize)
        .Include(x => x.Developers)
        .Include(x => x.Genres)
        .Include(x => x.Platforms)
        .Include(x => x.Publishers)
        .Include(x => x.Screenshots)
        .Include(x => x.Tags)
        .ToList();

      var gamesReply = new GamesReply() {
        Games = games
      };

      return await Task.FromResult(gamesReply);
    }

    #region Binding

    public async Task<GameReply> AddGenreToGame(AddGenreToGameRequest request) {
      var game = await _context.Games.FindAsync(request.GameId);
      var genre = await _context.Genres.FindAsync(request.GenreId);

      if (game is null) {
        throw new ArgumentNullException($"Could not find movie by id: {request.GameId}");
      } else if (game is null) {
        throw new ArgumentNullException($"Could not find genre by id: {request.GenreId}");
      }

      game.Genres.Add(genre);
      await _context.SaveChangesAsync();

      return new GameReply {
        Game = game
      };
    }

    public async Task<GameReply> AddTagToGame(AddTagToGameRequest request) {
      var game = await _context.Games.FindAsync(request.GameId);
      var tag = await _context.Tags.FindAsync(request.TagId);

      if (game is null) {
        throw new ArgumentNullException($"Could not find game by id: {request.GameId}");
      } else if (tag is null) {
        throw new ArgumentNullException($"Could not find tag by id: {request.TagId}");
      }

      game.Tags.Add(tag);
      await _context.SaveChangesAsync();

      return new GameReply {
        Game = game
      };
    }

    public async Task<GameReply> AddDeveloperToGame(AddDeveloperToGameRequest request) {
      var game = await _context.Games.FindAsync(request.GameId);
      var developer = await _context.Developers.FindAsync(request.DeveloperId);

      if (game is null) {
        throw new ArgumentNullException($"Could not find game by id: {request.GameId}");
      } else if (developer is null) {
        throw new ArgumentNullException($"Could not find developer by id: {request.DeveloperId}");
      }

      game.Developers.Add(developer);
      await _context.SaveChangesAsync();

      return new GameReply {
        Game = game
      };
    }

    public async Task<GameReply> AddPlatformToGame(AddPlatformToGameRequest request) {
      var game = await _context.Games.FindAsync(request.GameId);
      var platform = await _context.Platforms.FindAsync(request.PlatformId);

      if(game is null) {
        throw new ArgumentNullException($"Could not find game by id: {request.GameId}");
      } else if (platform is null) {
        throw new ArgumentNullException($"Could not find platform by id: {request.PlatformId}");
      }

      game.Platforms.Add(platform);
      await _context.SaveChangesAsync();

      return new GameReply {
        Game = game
      };
    }

    public async Task<GameReply> AddPublisherToGame(AddPublisherToGameRequest request) {
      var game = await _context.Games.FindAsync(request.GameId);
      var publisher = await _context.Publishers.FindAsync(request.PublisherId);

      if (game is null) {
        throw new ArgumentNullException($"Could not find game by id: {request.GameId}");
      } else if (publisher is null) {
        throw new ArgumentNullException($"Could not find publisher by id: {request.PublisherId}");
      }

      game.Publishers.Add(publisher);
      await _context.SaveChangesAsync();

      return new GameReply {
        Game = game
      };
    }

    public async Task<GameReply> AddScreenshotToGame(AddScreenshotToGameRequest request) {
      var game = await _context.Games.FindAsync(request.GameId);
      var screenshot = await _context.Images.FindAsync(request.ImageId);

      if (game is null) {
        throw new ArgumentNullException($"Could not find game by id: {request.GameId}");
      } else if (screenshot is null) {
        throw new ArgumentNullException($"Could not find screenshot by id: {request.ImageId}");
      }

      game.Screenshots.Add(screenshot);
      await _context.SaveChangesAsync();

      return new GameReply() {
        Game = game
      };
    }

    #endregion Binding
  }
}