using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Abstractions.Dictionaries {

  public interface IPublisherService {

    Task<PublisherReply> CreatePublisher(Publisher publisher);

    Task<PublisherReply> UpdatePublisher(Publisher publisher);

    Task<PublishersReply> RetrievePublishers();

    Task<PublisherReply> DeletePublisherById(int id);
  }
}