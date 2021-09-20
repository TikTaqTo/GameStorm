using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Genres.Create {

  public class CreateTagCommandHandler : IRequestHandler<CreateGenreCommand, GenreReply> {
    private readonly IGenreService _genreService;

    public CreateTagCommandHandler(IGenreService genreService) {
      _genreService = genreService;
    }

    public async Task<GenreReply> Handle(CreateGenreCommand request, CancellationToken cancellationToken) {
      return await _genreService.CreateGenre(request.Genre);
    }
  }
}