using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Platforms.Delete {

  public class DeletePlatformCommand : IRequest<PlatformReply> {
    public int Id { get; }

    public DeletePlatformCommand(int id) {
      Id = id;
    }
  }
}