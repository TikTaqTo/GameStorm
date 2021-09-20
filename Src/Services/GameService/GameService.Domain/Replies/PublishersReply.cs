using GameService.Domain.EntityModels.Dictionaries;
using System.Collections.Generic;

namespace GameService.Domain.Replies {

  public class PublishersReply : CommonReply {
    public IEnumerable<Publisher> Publishers { get; set; }
  }
}