using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Developers.Update {

  public class UpdateDeveloperCommand : IRequest<DeveloperReply> {
    public Developer Developer { get; }

    public UpdateDeveloperCommand(Developer developer) {
      Developer = developer;
    }
  }
}