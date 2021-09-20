using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Developers.Update {

  public class UpdateGenreCommand : IRequest<DeveloperReply> {
    public Developer Developer { get; }

    public UpdateGenreCommand(Developer developer) {
      Developer = developer;
    }
  }
}