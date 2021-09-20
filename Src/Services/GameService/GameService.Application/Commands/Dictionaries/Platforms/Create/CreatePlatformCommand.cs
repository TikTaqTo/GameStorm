using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using MediatR;

namespace GameService.Application.Commands.Dictionaries.Platforms.Create {

  public class CreatePlatformCommand : IRequest<PlatformReply> {
    public Platform Platform { get; }

    public CreatePlatformCommand(Platform platform) {
      Platform = platform;
    }
  }
}