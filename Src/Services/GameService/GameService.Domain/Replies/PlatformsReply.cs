using GameService.Domain.EntityModels.Dictionaries;
using System.Collections.Generic;

namespace GameService.Domain.Replies {

  public class PlatformsReply : CommonReply {
    public IEnumerable<Platform> Platforms { get; set; }
  }
}