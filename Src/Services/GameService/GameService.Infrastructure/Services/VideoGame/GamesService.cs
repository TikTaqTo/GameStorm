using GameService.Application.Abstractions.VideoGame;
using GameService.Domain.EntityModels.VideoGame;
using GameService.Domain.Replies;
using GameService.Domain.Requests;
using GameService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
      var allGames = _context.Games;
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
        .First();

      var gameReply = new GameReply() {
        Game = game
      };

      return await Task.FromResult(gameReply);
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
    #endregion
  }
}