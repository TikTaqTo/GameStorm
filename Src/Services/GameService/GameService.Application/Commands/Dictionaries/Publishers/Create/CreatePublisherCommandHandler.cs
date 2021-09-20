using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Publishers.Create {

  public class CreatePublisherCommandHandler : IRequestHandler<CreatePublisherCommand, PublisherReply> {
    private readonly IPublisherService _publisherService;

    public CreatePublisherCommandHandler(IPublisherService publisherService) {
      _publisherService = publisherService;
    }

    public async Task<PublisherReply> Handle(CreatePublisherCommand request, CancellationToken cancellationToken) {
      return await _publisherService.CreatePublisher(request.Publisher);
    }
  }
}