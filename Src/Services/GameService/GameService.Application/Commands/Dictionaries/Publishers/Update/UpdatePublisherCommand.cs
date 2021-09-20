using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Publishers.Update {

  public class UpdatePublisherCommand : IRequest<PublisherReply> {
    public Publisher Publisher { get; }

    public UpdatePublisherCommand(Publisher publisher) {
      Publisher = publisher;
    }
  }
}