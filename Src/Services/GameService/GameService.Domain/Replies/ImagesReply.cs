using GameService.Domain.EntityModels.Media;
using System.Collections.Generic;

namespace GameService.Domain.Replies {

  public class ImagesReply : CommonReply {
    public IEnumerable<Image> Images { get; set; }
  }
}