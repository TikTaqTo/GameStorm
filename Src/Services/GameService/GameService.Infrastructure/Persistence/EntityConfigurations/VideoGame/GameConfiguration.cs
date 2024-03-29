﻿using GameService.Domain.EntityModels.VideoGame;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Infrastructure.Persistence.EntityConfigurations.VideoGame {

  public class GameConfiguration : EntityBaseTypeConfiguration<Game, Guid> {

    protected override void ConfigureEntity(EntityTypeBuilder<Game> builder) {
      builder.Property(x => x.Title)
          .HasMaxLength(200)
          .IsRequired();
      builder.Property(x => x.NormalizedTitle)
          .HasMaxLength(250)
          .IsRequired();
    }
  }
}