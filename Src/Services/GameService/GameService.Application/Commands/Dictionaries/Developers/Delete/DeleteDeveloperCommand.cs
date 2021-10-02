using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Developers.Delete {

  public class DeleteDeveloperCommand : IRequest<DeveloperReply> {

    public DeleteDeveloperCommand(int id) {
      Id = id;
    }

    public int Id { get; }
  }
}