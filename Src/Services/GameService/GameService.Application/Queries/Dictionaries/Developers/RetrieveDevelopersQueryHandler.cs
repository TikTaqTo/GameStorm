using GameService.Application.Abstractions.Dictionaries;
using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GameService.Application.Queries.Dictionaries.Developers {

  public class RetrieveDevelopersQueryHandler : IRequestHandler<RetrieveDevelopersQuery, DevelopersReply> {
    private readonly IDeveloperService _developersService;

    public RetrieveDevelopersQueryHandler(IDeveloperService developersService) {
      _developersService = developersService;
    }

    public async Task<DevelopersReply> Handle(RetrieveDevelopersQuery request, CancellationToken cancellationToken) {
      return await _developersService.RetrieveDevelopers();
    }
  }
}