using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using UserIdentityService.Domain.EntityModels.User;

namespace UserIdentityService.Infrastructure.Persistence {
  public class UserIdentityServiceContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid> {
    public UserIdentityServiceContext() {
    }

    public UserIdentityServiceContext(DbContextOptions<UserIdentityServiceContext> options) : base(options) {
    }

    #region User

    public DbSet<ApplicationUser> ApplicationUsers { get; set; }

    #endregion User

    protected override void OnConfiguring(DbContextOptionsBuilder options) {
      if (!options.IsConfigured) {
        options.UseSqlServer("Data Source=DESKTOP-K2327PS;Initial Catalog=GameStorm.UserIdentityServiceDB;Integrated Security=True");
      }
      base.OnConfiguring(options);
    }

    protected override void OnModelCreating(ModelBuilder builder) {
      base.OnModelCreating(builder);
    }
  }
}
