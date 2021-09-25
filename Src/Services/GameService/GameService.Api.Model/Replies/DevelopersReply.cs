using GameService.Api.Model.Dictionaries;
using System.Collections.Generic;

namespace GameService.Api.Model.Replies {

  public class DevelopersReply : CommonReply {
    public IEnumerable<Developer> Developers { get; set; }
  }
}