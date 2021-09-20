using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Publishers.Delete {

  public class DeletePublisherCommand : IRequest<PublisherReply> {
    public int Id { get; }

    public DeletePublisherCommand(int id) {
      Id = id;
    }
  }
}