using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Publishers.Update {

  public class UpdatePublisherCommandHandler : IRequestHandler<UpdatePublisherCommand, PublisherReply> {
    private readonly IPublisherService _publisherService;

    public UpdatePublisherCommandHandler(IPublisherService publisherService) {
      _publisherService = publisherService;
    }

    public async Task<PublisherReply> Handle(UpdatePublisherCommand request, CancellationToken cancellationToken) {
      return await _publisherService.UpdatePublisher(request.Publisher);
    }
  }
}