using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Api.Model.Requests {

  public class AddDeveloperToGameRequest {
    public Guid GameId { get; set; }
    public int DeveloperId { get; set; }
  }
}