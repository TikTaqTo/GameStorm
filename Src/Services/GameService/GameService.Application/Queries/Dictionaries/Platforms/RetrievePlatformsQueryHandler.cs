using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Queries.Dictionaries.Platforms {

  public class RetrievePlatformsQueryHandler : IRequestHandler<RetrievePlatformsQuery, PlatformsReply> {
    private readonly IPlatformService _platformService;

    public RetrievePlatformsQueryHandler(IPlatformService platformService) {
      _platformService = platformService;
    }

    public async Task<PlatformsReply> Handle(RetrievePlatformsQuery request, CancellationToken cancellationToken) {
      return await _platformService.RetrievePlatforms();
    }
  }
}