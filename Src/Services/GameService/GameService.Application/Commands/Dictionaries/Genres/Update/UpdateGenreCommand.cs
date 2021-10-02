using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Genres.Update {

  public class UpdateGenreCommand : IRequest<GenreReply> {
    public Genre Genre { get; }

    public UpdateGenreCommand(Genre genre) {
      Genre = genre;
    }
  }
}