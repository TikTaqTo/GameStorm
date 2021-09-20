using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Tags.Create {

  public class CreateTagCommandHandler : IRequestHandler<CreateTagCommand, TagReply> {
    private readonly ITagService _tagService;

    public CreateTagCommandHandler(ITagService tagService) {
      _tagService = tagService;
    }

    public async Task<TagReply> Handle(CreateTagCommand request, CancellationToken cancellationToken) {
      return await _tagService.CreateTag(request.Tag);
    }
  }
}