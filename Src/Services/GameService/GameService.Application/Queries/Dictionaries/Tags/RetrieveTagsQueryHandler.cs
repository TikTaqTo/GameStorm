using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Queries.Dictionaries.Tags {

  public class RetrieveTagsQueryHandler : IRequestHandler<RetrieveTagsQuery, TagsReply> {
    private readonly ITagService _tagService;

    public RetrieveTagsQueryHandler(ITagService tagService) {
      _tagService = tagService;
    }

    public async Task<TagsReply> Handle(RetrieveTagsQuery request, CancellationToken cancellationToken) {
      return await _tagService.RetrieveTags();
    }
  }
}