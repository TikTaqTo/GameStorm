using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using GameService.Infrastructure.Persistence;
using System;
using System.Threading.Tasks;

namespace GameService.Infrastructure.Services.Dictionaries {

  public class DeveloperService : IDeveloperService {
    private readonly GameServiceContext _context;

    public DeveloperService(GameServiceContext context) {
      _context = context;
    }

    public async Task<DeveloperReply> CreateDeveloper(Developer developer) {
      await _context.Developers.AddAsync(developer);
      await _context.SaveChangesAsync();
      return new DeveloperReply() {
        Developer = developer
      };
    }

    public async Task<DeveloperReply> DeleteDeveloperById(int id) {
      var developer = _context.Developers.Find(id);
      developer.DeletedAt = DateTimeOffset.Now;
      developer.DeletedBy = "admin";
      developer.DeletedReason = "delete info";
      await _context.SaveChangesAsync();
      return new DeveloperReply {
        Developer = developer
      };
    }

    public async Task<DevelopersReply> RetrieveDevelopers() {
      var allDeveloper = _context.Developers;
      var developersReply = new DevelopersReply() {
        Developers = allDeveloper
      };
      return await Task.FromResult(developersReply);
    }

    public async Task<DeveloperReply> UpdateDeveloper(Developer developer) {
      _context.Developers.Update(developer);
      await _context.SaveChangesAsync();
      return new DeveloperReply {
        Developer = developer
      };
    }
  }
}