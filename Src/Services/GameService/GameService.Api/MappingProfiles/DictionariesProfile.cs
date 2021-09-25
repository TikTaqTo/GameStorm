using AutoMapper;
using GameService.Api.Model.Dictionaries;
using GameService.Api.Model.Replies;

namespace GameService.Api.MappingProfiles {
  public class DictionariesProfile : Profile {
    public DictionariesProfile() {
      CreateMap<CommonReply, Domain.Replies.CommonReply>().ReverseMap();
      CreateMap<DeveloperReply, Domain.Replies.DeveloperReply>().ReverseMap();
      CreateMap<DevelopersReply, Domain.Replies.DevelopersReply>().ReverseMap();
      CreateMap<GameReply, Domain.Replies.GameReply>().ReverseMap();
      CreateMap<GamesReply, Domain.Replies.GamesReply>().ReverseMap();
      CreateMap<GenreReply, Domain.Replies.GenreReply>().ReverseMap();
      CreateMap<GenresReply, Domain.Replies.GenresReply>().ReverseMap();
      CreateMap<ImageReply, Domain.Replies.ImageReply>().ReverseMap();
      CreateMap<ImagesReply, Domain.Replies.ImagesReply>().ReverseMap();
      CreateMap<PlatformReply, Domain.Replies.PlatformReply>().ReverseMap();
      CreateMap<PlatformsReply, Domain.Replies.PlatformsReply>().ReverseMap();
      CreateMap<PublisherReply, Domain.Replies.PublisherReply>().ReverseMap();
      CreateMap<PublishersReply, Domain.Replies.PublishersReply>().ReverseMap();
      CreateMap<TagReply, Domain.Replies.TagReply>().ReverseMap();
      CreateMap<TagsReply, Domain.Replies.TagsReply>().ReverseMap();
    }
  }
}
