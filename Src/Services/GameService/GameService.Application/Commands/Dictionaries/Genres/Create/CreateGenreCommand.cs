using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Genres.Create {

  public class CreateGenreCommand : IRequest<GenreReply> {
    public Genre Genre { get; }

    public CreateGenreCommand(Genre genre) {
      Genre = genre;
    }
  }
}