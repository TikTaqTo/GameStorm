using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserIdentityService.Api.Models.Requests;
using UserIdentityService.Api.Models.Responses;

namespace UserIdentityService.Api.MappingProfiles {
  public class SecurityProfile : Profile {

    public SecurityProfile() {
      CreateMap<RegisterRequest, Domain.Requests.RegisterRequest>()
          .ReverseMap();
      CreateMap<LoginRequest, Domain.Requests.LoginRequest>()
               .ReverseMap();
      CreateMap<UserManagerResponse, Domain.Responses.UserManagerResponse>()
                .ReverseMap();
    }
  }
}
