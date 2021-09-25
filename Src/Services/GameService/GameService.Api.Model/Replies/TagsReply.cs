using GameService.Api.Model.Dictionaries;
using System.Collections.Generic;

namespace GameService.Api.Model.Replies {

  public class TagsReply : CommonReply {
    public IEnumerable<Tag> Tags { get; set; }
  }
}