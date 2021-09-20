using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Tags.Delete {

  public class DeleteTagCommand : IRequest<TagReply> {
    public int Id { get; }

    public DeleteTagCommand(int id) {
      Id = id;
    }
  }
}