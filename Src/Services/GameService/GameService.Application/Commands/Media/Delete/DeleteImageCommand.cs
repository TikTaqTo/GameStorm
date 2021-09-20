using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Media.Delete {

  public class DeleteImageCommand : IRequest<ImageReply> {
    public Guid Id { get; }

    public DeleteImageCommand(Guid id) {
      Id = id;
    }
  }
}