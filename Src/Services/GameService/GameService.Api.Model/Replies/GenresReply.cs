using GameService.Api.Model.Dictionaries;
using System.Collections.Generic;

namespace GameService.Api.Model.Replies {

  public class GenresReply : CommonReply {
    public IEnumerable<Genre> Genres { get; set; }
  }
}