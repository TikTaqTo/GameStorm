using GameService.Domain.EntityModels.Dictionaries;
using System.Collections.Generic;

namespace GameService.Domain.Replies {

  public class GenresReply : CommonReply {
    public IEnumerable<Genre> Genres { get; set; }
  }
}