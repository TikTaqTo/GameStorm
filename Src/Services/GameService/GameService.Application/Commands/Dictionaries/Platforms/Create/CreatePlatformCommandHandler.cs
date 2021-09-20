using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Platforms.Create {

  public class CreatePlatformCommandHandler : IRequestHandler<CreatePlatformCommand, PlatformReply> {
    private readonly IPlatformService _platformService;

    public CreatePlatformCommandHandler(IPlatformService platformService) {
      _platformService = platformService;
    }

    public async Task<PlatformReply> Handle(CreatePlatformCommand request, CancellationToken cancellationToken) {
      return await _platformService.CreatePlatform(request.Platform);
    }
  }
}