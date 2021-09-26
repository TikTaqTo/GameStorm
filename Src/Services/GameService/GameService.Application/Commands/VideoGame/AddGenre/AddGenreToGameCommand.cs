using GameService.Domain.Replies;
using GameService.Domain.Requests;
using MediatR;

namespace GameService.Application.Commands.VideoGame.AddGenre {
  public class AddGenreToGameCommand : IRequest<GameReply> {
    public AddGenreToGameRequest Request { get; }

    public AddGenreToGameCommand(AddGenreToGameRequest request) {
      Request = request;
    }
  }
}
