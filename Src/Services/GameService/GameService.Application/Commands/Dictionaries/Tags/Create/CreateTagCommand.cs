using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Tags.Create {

  public class CreateTagCommand : IRequest<TagReply> {
    public Tag Tag { get; }

    public CreateTagCommand(Tag tag) {
      Tag = tag;
    }
  }
}