﻿using GameService.Domain.Replies;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Application.Queries.VideoGame {

  public class RetrieveGamesAtReleaseYearQuery : IRequest<GamesReply> {

    public RetrieveGamesAtReleaseYearQuery(DateTimeOffset date) {
      Date = date;
    }

    public DateTimeOffset Date { get; }
  }
}