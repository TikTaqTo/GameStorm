using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Platforms.Delete {

  public class DeletePlatformCommandHandler : IRequestHandler<DeletePlatformCommand, PlatformReply> {
    private readonly IPlatformService _platformService;

    public DeletePlatformCommandHandler(IPlatformService platformService) {
      _platformService = platformService;
    }

    public async Task<PlatformReply> Handle(DeletePlatformCommand request, CancellationToken cancellationToken) {
      return await _platformService.DeletePlatformById(request.Id);
    }
  }
}