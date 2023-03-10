using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using GameService.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameService.Infrastructure.Services.Dictionaries {

  public class PlatformService : IPlatformService {
    private readonly GameServiceContext _context;

    public PlatformService(GameServiceContext context) {
        _context = context;
        
        List<Platform> platforms = new List<Platform>() { 
            new Platform() { Id = 1, Name = "Web", NormalizedName = "web"},
            new Platform() { Id = 2, Name = "PC", NormalizedName = "pc"},
            new Platform() { Id = 3, Name = "PlayStation", NormalizedName = "playstation"},
            new Platform() { Id = 4, Name = "Xbox", NormalizedName = "xbox"}
        };

        _context.Platforms.AddRange(platforms);
        _context.SaveChanges();
    }

    public async Task<PlatformReply> CreatePlatform(Platform platform) {
      await _context.Platforms.AddAsync(platform);
      await _context.SaveChangesAsync();
      return new PlatformReply() {
        Platform = platform
      };
    }

    public async Task<PlatformReply> DeletePlatformById(int id) {
      var platform = _context.Platforms.Find(id);
      platform.DeletedAt = DateTimeOffset.Now;
      platform.DeletedBy = "admin";
      platform.DeletedReason = "delete info";
      await _context.SaveChangesAsync();
      return new PlatformReply {
        Platform = platform
      };
    }

    public async Task<PlatformsReply> RetrievePlatforms() {
      var allPlatforms = _context.Platforms;
      var platformsReply = new PlatformsReply() {
        Platforms = allPlatforms
      };
      return await Task.FromResult(platformsReply);
    }

    public async Task<PlatformReply> UpdatePlatform(Platform platform) {
      _context.Platforms.Update(platform);
      await _context.SaveChangesAsync();
      return new PlatformReply() {
        Platform = platform
      };
    }
  }
}