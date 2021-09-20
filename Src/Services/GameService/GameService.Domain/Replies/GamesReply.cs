using GameService.Domain.EntityModels.VideoGame;
using System.Collections.Generic;

namespace GameService.Domain.Replies {

  public class GamesReply : CommonReply {
    public IEnumerable<Game> Games { get; set; }
  }
}