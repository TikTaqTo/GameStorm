using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Publishers.Delete {

  public class DeletePublisherCommandHandler : IRequestHandler<DeletePublisherCommand, PublisherReply> {
    private readonly IPublisherService _publisherService;

    public DeletePublisherCommandHandler(IPublisherService publisherService) {
      _publisherService = publisherService;
    }

    public async Task<PublisherReply> Handle(DeletePublisherCommand request, CancellationToken cancellationToken) {
      return await _publisherService.DeletePublisherById(request.Id);
    }
  }
}