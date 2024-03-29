﻿using GameService.Domain.EntityModels.Dictionaries;
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

    public DbSet<Game> Games { get; set; }

    #endregion Game

    #region Dictionaries

    public DbSet<Developer> Developers { get; set; }
    public DbSet<Genre> Genres { get; set; }
    public DbSet<Platform> Platforms { get; set; }
    public DbSet<Publisher> Publishers { get; set; }
    public DbSet<Tag> Tags { get; set; }

    #endregion Dictionaries

    #region Media

    public DbSet<Image> Images { get; set; }

    #endregion Media

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
      if (!options.IsConfigured) {
        options.UseSqlServer("Data Source=DESKTOP-4M2HR8M;Initial Catalog=GameStormServiceTest;Integrated Security=True");
      }
      base.OnConfiguring(options);
    }

    protected override void OnModelCreating(ModelBuilder builder) {
      base.OnModelCreating(builder);
    }
  }
}
