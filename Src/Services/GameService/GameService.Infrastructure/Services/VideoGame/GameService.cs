using GameService.Application.Abstractions.VideoGame;
using GameService.Domain.EntityModels.VideoGame;
using GameService.Domain.Replies;
using GameService.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Infrastructure.Services.VideoGame {

  public class GameService : IGameService {
    private readonly GameServiceContext _context;

    public GameService(GameServiceContext context) {
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
  }
}