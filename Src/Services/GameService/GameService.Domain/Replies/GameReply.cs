using GameService.Domain.EntityModels.VideoGame;

namespace GameService.Domain.Replies {

  public class GameReply : CommonReply {
    public Game Game { get; set; }
  }
}