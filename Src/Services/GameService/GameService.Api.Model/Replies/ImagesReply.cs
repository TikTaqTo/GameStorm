using GameService.Api.Model.Media;
using System.Collections.Generic;

namespace GameService.Api.Model.Replies {

  public class ImagesReply : CommonReply {
    public IEnumerable<Image> Images { get; set; }
  }
}