using AutoMapper;
using GameService.Api.Model.Dictionaries;
using GameService.Api.Model.Media;
using GameService.Api.Model.Replies;
using GameService.Api.Model.VideoGame;

namespace GameService.Api.MappingProfiles {
  public class DictionariesProfile : Profile {
    public DictionariesProfile() {
      CreateMap<CommonReply, Domain.Replies.CommonReply>().ReverseMap();
      CreateMap<DeveloperReply, Domain.Replies.DeveloperReply>().ReverseMap();
      CreateMap<DevelopersReply, Domain.Replies.DevelopersReply>().ReverseMap();
      CreateMap<GenreReply, Domain.Replies.GenreReply>().ReverseMap();
      CreateMap<GenresReply, Domain.Replies.GenresReply>().ReverseMap();
      CreateMap<PlatformReply, Domain.Replies.PlatformReply>().ReverseMap();
      CreateMap<PlatformsReply, Domain.Replies.PlatformsReply>().ReverseMap();
      CreateMap<PublisherReply, Domain.Replies.PublisherReply>().ReverseMap();
      CreateMap<PublishersReply, Domain.Replies.PublishersReply>().ReverseMap();
      CreateMap<TagReply, Domain.Replies.TagReply>().ReverseMap();
      CreateMap<TagsReply, Domain.Replies.TagsReply>().ReverseMap();

      CreateMap<Developer, Domain.EntityModels.Dictionaries.Developer>().ReverseMap();
      CreateMap<Genre, Domain.EntityModels.Dictionaries.Genre>().ReverseMap();
      CreateMap<Platform, Domain.EntityModels.Dictionaries.Platform>().ReverseMap();
      CreateMap<Publisher, Domain.EntityModels.Dictionaries.Publisher>().ReverseMap();
      CreateMap<Tag, Domain.EntityModels.Dictionaries.Tag>().ReverseMap();
    }
  }
}
