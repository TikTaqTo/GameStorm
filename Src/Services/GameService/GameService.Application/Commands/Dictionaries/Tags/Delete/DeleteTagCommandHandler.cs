using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Tags.Delete {

  public class DeleteTagCommandHandler : IRequestHandler<DeleteTagCommand, TagReply> {
    private readonly ITagService _tagService;

    public DeleteTagCommandHandler(ITagService tagService) {
      _tagService = tagService;
    }

    public async Task<TagReply> Handle(DeleteTagCommand request, CancellationToken cancellationToken) {
      return await _tagService.DeleteTagById(request.Id);
    }
  }
}