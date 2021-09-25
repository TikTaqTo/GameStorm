using GameService.Api.Model.Dictionaries;
using System.Collections.Generic;

namespace GameService.Api.Model.Replies {

  public class PublishersReply : CommonReply {
    public IEnumerable<Publisher> Publishers { get; set; }
  }
}