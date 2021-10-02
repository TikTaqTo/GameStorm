using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Developers.Delete {

  public class DeleteDeveloperCommandHandler : IRequestHandler<DeleteDeveloperCommand, DeveloperReply> {
    private readonly IDeveloperService _developerService;

    public DeleteDeveloperCommandHandler(IDeveloperService developerService) {
      _developerService = developerService;
    }

    public async Task<DeveloperReply> Handle(DeleteDeveloperCommand request, CancellationToken cancellationToken) {
      return await _developerService.DeleteDeveloperById(request.Id);
    }
  }
}