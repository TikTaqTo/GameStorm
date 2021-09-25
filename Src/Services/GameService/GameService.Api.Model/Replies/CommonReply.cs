using System.Collections.Generic;

namespace GameService.Api.Model.Replies {

  public class CommonReply {
    public IEnumerable<string> Errors { get; set; }
    public IEnumerable<string> Warnings { get; set; }
  }
}