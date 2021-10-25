using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Domain.Requests {
  public class AddScreenshotToGameRequest {
    public Guid GameId { get; set; }
    public Guid ImageId { get; set; }
  }
}
