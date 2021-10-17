using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.EntityModels.Media;
using GameService.Domain.EntityModels.VideoGame;
using Microsoft.EntityFrameworkCore;

namespace GameService.Infrastructure.Persistence {

  public class GameServiceContext : DbContext {

    public GameServiceContext() {
    }

    public GameServiceContext(DbContextOptions<GameServiceContext> options) : base(options) {
    }

    #region Game

    public virtual DbSet<Game> Games { get; set; }

    #endregion Game

    #region Dictionaries

    public virtual DbSet<Developer> Developers { get; set; }
    public virtual DbSet<Genre> Genres { get; set; }
    public virtual DbSet<Platform> Platforms { get; set; }
    public virtual DbSet<Publisher> Publishers { get; set; }
    public virtual DbSet<Tag> Tags { get; set; }

    #endregion Dictionaries

    #region Media

    public virtual DbSet<Image> Images { get; set; }

    #endregion Media

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
      if (!options.IsConfigured) {
        options.UseSqlServer("Data Source=DESKTOP-K2327PS;Initial Catalog=GameStorm.GameService;Integrated Security=True");
      }
      base.OnConfiguring(options);
    }

    protected override void OnModelCreating(ModelBuilder builder) {
      base.OnModelCreating(builder);
    }
  }
}