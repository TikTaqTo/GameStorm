using AutoMapper;
using GameService.Api.Model.Media;
using GameService.Api.Model.Replies;

namespace GameService.Api.MappingProfiles {
  public class GamesProfile : Profile {
    public GamesProfile() {
      CreateMap<GameReply, Domain.Replies.GameReply>().ReverseMap();
      CreateMap<GamesReply, Domain.Replies.GamesReply>().ReverseMap();
    }
  }
}
