using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Genres.Update {

  public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, GenreReply> {
    private readonly IGenreService _genreService;

    public UpdateGenreCommandHandler(IGenreService genreService) {
      _genreService = genreService;
    }

    public async Task<GenreReply> Handle(UpdateGenreCommand request, CancellationToken cancellationToken) {
      return await _genreService.UpdateGenre(request.Genre);
    }
  }
}