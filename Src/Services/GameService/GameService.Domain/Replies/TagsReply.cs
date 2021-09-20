using GameService.Domain.EntityModels.Dictionaries;
using System.Collections.Generic;

namespace GameService.Domain.Replies {

  public class TagsReply : CommonReply {
    public IEnumerable<Tag> Tags { get; set; }
  }
}