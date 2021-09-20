using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Queries.Dictionaries.Publishers {

  public class RetrievePublishersQueryHandler : IRequestHandler<RetrievePublishersQuery, PublishersReply> {
    private readonly IPublisherService _publisherService;

    public RetrievePublishersQueryHandler(IPublisherService publisherService) {
      _publisherService = publisherService;
    }

    public async Task<PublishersReply> Handle(RetrievePublishersQuery request, CancellationToken cancellationToken) {
      return await _publisherService.RetrievePublishers();
    }
  }
}