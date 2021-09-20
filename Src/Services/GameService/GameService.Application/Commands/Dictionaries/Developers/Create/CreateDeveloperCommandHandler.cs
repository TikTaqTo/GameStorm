using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Commands.Dictionaries.Developers.Create {

  public class CreateDeveloperCommandHandler : IRequestHandler<CreateGenreCommand, DeveloperReply> {
    private readonly IDeveloperService _developerRepository;

    public CreateDeveloperCommandHandler(IDeveloperService developerRepository) {
      _developerRepository = developerRepository;
    }

    public async Task<DeveloperReply> Handle(CreateGenreCommand request, CancellationToken cancellationToken) {
      return await _developerRepository.CreateDeveloper(request.Developer);
    }
  }
}