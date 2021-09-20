using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Genres.Delete {

  public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, GenreReply> {
    private readonly IGenreService _genreService;

    public DeleteTagCommandHandler(IGenreService genreService) {
      _genreService = genreService;
    }

    public async Task<GenreReply> Handle(DeleteTagCommand request, CancellationToken cancellationToken) {
      return await _genreService.DeleteGenreById(request.Id);
    }
  }
}