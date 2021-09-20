using GameService.Domain.Replies;
using MediatR;
using GameService.Domain.EntityModels.Dictionaries;

namespace GameService.Application.Commands.Dictionaries.Developers.Create {

  public class CreateGenreCommand : IRequest<DeveloperReply> {

    public CreateGenreCommand(Developer developer) {
      Developer = developer;
    }

    public Developer Developer { get; }
  }
}