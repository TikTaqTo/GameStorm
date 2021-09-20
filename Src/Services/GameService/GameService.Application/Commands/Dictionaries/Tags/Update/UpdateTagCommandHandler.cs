using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Tags.Update {

  public class UpdateTagCommandHandler : IRequestHandler<UpdateTagCommand, TagReply> {
    private readonly ITagService _tagService;

    public UpdateTagCommandHandler(ITagService tagService) {
      _tagService = tagService;
    }

    public async Task<TagReply> Handle(UpdateTagCommand request, CancellationToken cancellationToken) {
      return await _tagService.UpdateTag(request.Tag);
    }
  }
}