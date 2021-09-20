using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Platforms.Update {

  public class UpdatePlatformCommandHandler : IRequestHandler<UpdatePlatformCommand, PlatformReply> {
    private readonly IPlatformService _platformService;

    public UpdatePlatformCommandHandler(IPlatformService platformService) {
      _platformService = platformService;
    }

    public async Task<PlatformReply> Handle(UpdatePlatformCommand request, CancellationToken cancellationToken) {
      return await _platformService.UpdatePlatform(request.Platform);
    }
  }
}