using GameService.Domain.Replies;
using MediatR;
using GameService.Domain.EntityModels.Dictionaries;

namespace GameService.Application.Commands.Dictionaries.Developers.Create {

  public class CreateDeveloperCommand : IRequest<DeveloperReply> {

    public CreateDeveloperCommand(Developer developer) {
      Developer = developer;
    }

    public Developer Developer { get; }
  }
}