using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Domain.Requests {

  public class AddGenreToGameRequest {
    public Guid GameId { get; set; }
    public int GenreId { get; set; }
  }
}