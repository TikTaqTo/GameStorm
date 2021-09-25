﻿using GameService.Api.Model.Dictionaries;
using System.Collections.Generic;

namespace GameService.Api.Model.Replies {

  public class PlatformsReply : CommonReply {
    public IEnumerable<Platform> Platforms { get; set; }
  }
}