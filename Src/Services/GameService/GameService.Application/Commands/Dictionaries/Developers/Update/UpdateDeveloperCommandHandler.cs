using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Developers.Update {

  public class UpdateGenreCommandHandler : IRequestHandler<UpdateGenreCommand, DeveloperReply> {
    private readonly IDeveloperService _developerService;

    public UpdateGenreCommandHandler(IDeveloperService developerService) {
      _developerService = developerService;
    }

    public async Task<DeveloperReply> Handle(UpdateGenreCommand request, CancellationToken cancellationToken) {
      return await _developerService.UpdateDeveloper(request.Developer);
    }
  }
}