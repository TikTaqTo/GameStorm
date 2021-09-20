using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Queries.Dictionaries.Genres {

  public class RetrieveGenresQueryHandler : IRequestHandler<RetrieveGenresQuery, GenresReply> {
    private readonly IGenreService _genresService;

    public RetrieveGenresQueryHandler(IGenreService genresService) {
      _genresService = genresService;
    }

    public async Task<GenresReply> Handle(RetrieveGenresQuery request, CancellationToken cancellationToken) {
      return await _genresService.RetrieveGenres();
    }
  }
}