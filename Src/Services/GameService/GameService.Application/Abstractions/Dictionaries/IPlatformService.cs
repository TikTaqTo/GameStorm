using GameService.Domain.EntityModels.Dictionaries;
using GameService.Domain.Replies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Abstractions.Dictionaries {

  public interface IPlatformService {

    Task<PlatformReply> CreatePlatform(Platform platform);

    Task<PlatformReply> UpdatePlatform(Platform platform);

    Task<PlatformsReply> RetrievePlatforms();

    Task<PlatformReply> DeletePlatformById(int id);
  }
}