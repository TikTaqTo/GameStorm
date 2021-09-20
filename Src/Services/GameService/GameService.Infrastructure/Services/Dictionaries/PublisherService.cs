using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using GameService.Infrastructure.Persistence;
using System;
using System.Threading.Tasks;

namespace GameService.Infrastructure.Services.Dictionaries {

  public class PublisherService : IPublisherService {
    private readonly GameServiceContext _context;

    public PublisherService(GameServiceContext context) {
      _context = context;
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