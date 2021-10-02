using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Genres.Delete {

  public class DeleteGenreCommand : IRequest<GenreReply> {
    public int Id { get; }

    public DeleteGenreCommand(int id) {
      Id = id;
    }
  }
}