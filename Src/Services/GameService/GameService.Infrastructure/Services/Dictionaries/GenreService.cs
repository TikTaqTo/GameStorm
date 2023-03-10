using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using GameService.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameService.Infrastructure.Services.Dictionaries {

  public class GenreService : IGenreService {
    private readonly GameServiceContext _context;

    public GenreService(GameServiceContext context) {
        _context = context;
         
        List<Genre> genres = new List<Genre>() { 
            new Genre() { Id = 1, Name = "Action", NormalizedName = "action"},
            new Genre() { Id = 2, Name = "Adventure", NormalizedName = "adventure"},
            new Genre() { Id = 3, Name = "Rpg", NormalizedName = "rpg"},
            new Genre() { Id = 4, Name = "Shooters", NormalizedName = "shooters"},
            new Genre() { Id = 5, Name = "Puzzle", NormalizedName = "puzzle"},
        };

        _context.Genres.AddRange(genres);
        _context.SaveChanges();
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