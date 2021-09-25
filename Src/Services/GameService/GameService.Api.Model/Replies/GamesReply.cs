using GameService.Api.Model.VideoGame;
using System.Collections.Generic;

namespace GameService.Api.Model.Replies {

  public class GamesReply : CommonReply {
    public IEnumerable<Game> Games { get; set; }
  }
}