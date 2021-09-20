using GameService.Domain.EntityModels.VideoGame;
using GameService.Domain.Replies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Abstractions.VideoGame {

  public interface IGameService {

    Task<GameReply> CreateGame(Game game);

    Task<GameReply> UpdateGame(Game game);

    Task<GamesReply> RetrieveGames();

    Task<GameReply> DeleteGameById(Guid id);
  }
}