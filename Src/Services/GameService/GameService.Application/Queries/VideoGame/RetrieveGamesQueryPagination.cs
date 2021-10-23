﻿using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {
  public class RetrieveGamesQueryPagination : IRequest<GamesReply> {
    public RetrieveGamesQueryPagination(int page, int pageSize) {
      Page = page;
      PageSize = pageSize;
    }

    public int Page { get; }
    public int PageSize { get; }
  }
}
