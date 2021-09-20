using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Platforms.Update {

  public class UpdatePlatformCommand : IRequest<PlatformReply> {
    public Platform Platform { get; }

    public UpdatePlatformCommand(Platform platform) {
      Platform = platform;
    }
  }
}