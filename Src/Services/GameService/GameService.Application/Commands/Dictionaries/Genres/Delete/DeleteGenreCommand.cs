using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Genres.Delete {

  public class DeleteTagCommand : IRequest<GenreReply> {
    public int Id { get; }

    public DeleteTagCommand(int id) {
      Id = id;
    }
  }
}