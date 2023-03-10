using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using GameService.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GameService.Infrastructure.Services.Dictionaries {

  public class PublisherService : IPublisherService {
    private readonly GameServiceContext _context;

    public PublisherService(GameServiceContext context) {
        _context = context;

        List<Publisher> publishers = new List<Publisher>() { 
            new Publisher (){ Id = 1, Name = "CD PROJEKT RED", NormalizedName = "cd projekt red" },
            new Publisher (){ Id = 2, Name = "Electronic Arts", NormalizedName = "electronic arts" },
            new Publisher (){ Id = 3, Name = "Valve", NormalizedName = "valve" },
            new Publisher (){ Id = 4, Name = "Sony Interactive Entertainment", NormalizedName = "sony interactive entertainment" },
            new Publisher (){ Id = 5, Name = "Rockstar Games", NormalizedName = "rockstar games" },
        };

        _context.Publishers.AddRange(publishers);
        _context.SaveChanges();
    }

    public async Task<PublisherReply> CreatePublisher(Publisher publisher) {
      await _context.Publishers.AddAsync(publisher);
      await _context.SaveChangesAsync();
      return new PublisherReply() {
        Publisher = publisher
      };
    }

    public async Task<PublisherReply> DeletePublisherById(int id) {
      var publisher = _context.Publishers.Find(id);
      publisher.DeletedAt = DateTimeOffset.Now;
      publisher.DeletedBy = "admin";
      publisher.DeletedReason = "delete info";
      await _context.SaveChangesAsync();
      return new PublisherReply {
        Publisher = publisher
      };
    }

    public async Task<PublishersReply> RetrievePublishers() {
      var allPublishers = _context.Publishers;
      var publishersReply = new PublishersReply() {
        Publishers = allPublishers
      };
      return await Task.FromResult(publishersReply);
    }

    public async Task<PublisherReply> UpdatePublisher(Publisher publisher) {
      _context.Publishers.Update(publisher);
      await _context.SaveChangesAsync();
      return new PublisherReply() {
        Publisher = publisher
      };
    }
  }
}