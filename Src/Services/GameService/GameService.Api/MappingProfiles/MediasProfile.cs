using AutoMapper;
using GameService.Api.Model.Media;
using GameService.Api.Model.Replies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameService.Api.MappingProfiles {
  public class MediasProfile : Profile {

    public MediasProfile() {
      CreateMap<ImagesReply, Domain.Replies.ImagesReply>().ReverseMap();
      CreateMap<ImageReply, Domain.Replies.ImageReply>().ReverseMap();
      CreateMap<Image, Domain.EntityModels.Media.Image>().ReverseMap();
    }
  }
}
