using GameService.Domain.EntityModels.Dictionaries;
using System.Collections.Generic;

namespace GameService.Domain.Replies {

  public class DevelopersReply : CommonReply {
    public IEnumerable<Developer> Developers { get; set; }
  }
}