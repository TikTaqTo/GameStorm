using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Api.Model.Requests {

  public class AddPublisherToGameRequest {
    public Guid GameId { get; set; }
    public int PublisherId { get; set; }
  }
}