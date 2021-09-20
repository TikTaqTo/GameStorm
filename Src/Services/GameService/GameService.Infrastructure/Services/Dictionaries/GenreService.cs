using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using GameService.Infrastructure.Persistence;
using System;
using System.Threading.Tasks;

namespace GameService.Infrastructure.Services.Dictionaries {

  public class GenreService : IGenreService {
    private readonly GameServiceContext _context;

    public GenreService(GameServiceContext context) {
      _context = context;
    }

    public async Task<GenreReply> CreateGenre(Genre genre) {
      await _context.Genres.AddAsync(genre);
      await _context.SaveChangesAsync();
      return new GenreReply() {
        Genre = genre
      };
    }

    public async Task<GenreReply> DeleteGenreById(int id) {
      var genre = _context.Genres.Find(id);
      genre.DeletedAt = DateTimeOffset.Now;
      genre.DeletedBy = "admin";
      genre.DeletedReason = "delete info";
      await _context.SaveChangesAsync();
      return new GenreReply {
        Genre = genre
      };
    }

    public async Task<GenresReply> RetrieveGenres() {
      var allGenre = _context.Genres;
      var genresReply = new GenresReply() {
        Genres = allGenre
      };
      return await Task.FromResult(genresReply);
    }

    public async Task<GenreReply> UpdateGenre(Genre genre) {
      _context.Genres.Update(genre);
      await _context.SaveChangesAsync();
      return new GenreReply() {
        Genre = genre
      };
    }
  }
}