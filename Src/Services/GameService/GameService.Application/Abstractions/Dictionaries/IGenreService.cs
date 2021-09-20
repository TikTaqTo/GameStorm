using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Abstractions.Dictionaries {

  public interface IGenreService {

    Task<GenreReply> CreateGenre(Genre genre);

    Task<GenreReply> UpdateGenre(Genre genre);

    Task<GenresReply> RetrieveGenres();

    Task<GenreReply> DeleteGenreById(int id);
  }
}