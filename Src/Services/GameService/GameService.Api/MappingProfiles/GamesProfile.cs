using AutoMapper;
using GameService.Api.Model.Requests;
using GameService.Api.Model.Replies;
using GameService.Api.Model.VideoGame;

namespace GameService.Api.MappingProfiles {

  public class GamesProfile : Profile {

    public GamesProfile() {
      CreateMap<GameReply, Domain.Replies.GameReply>().ReverseMap();
      CreateMap<GamesReply, Domain.Replies.GamesReply>().ReverseMap();

      CreateMap<Game, Domain.EntityModels.VideoGame.Game>().ReverseMap();

      CreateMap<AddDeveloperToGameRequest, Domain.Requests.AddDeveloperToGameRequest>().ReverseMap();
      CreateMap<AddGenreToGameRequest, Domain.Requests.AddGenreToGameRequest>().ReverseMap();
      CreateMap<AddPlatformToGameRequest, Domain.Requests.AddPlatformToGameRequest>().ReverseMap();
      CreateMap<AddPublisherToGameRequest, Domain.Requests.AddPublisherToGameRequest>().ReverseMap();
      CreateMap<AddTagToGameRequest, Domain.Requests.AddTagToGameRequest>().ReverseMap();
      CreateMap<AddScreenshotToGameRequest, Domain.Requests.AddScreenshotToGameRequest>().ReverseMap();
    }
  }
}