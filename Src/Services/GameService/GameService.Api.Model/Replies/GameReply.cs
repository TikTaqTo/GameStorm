using GameService.Api.Model.VideoGame;

namespace GameService.Api.Model.Replies {

  public class GameReply : CommonReply {
    public Game Game { get; set; }
  }
}