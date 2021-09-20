using GameService.Domain.EntityModels.Dictionaries;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Infrastructure.Persistence.EntityConfigurations.Dictionaries {

  public class PlatformConfiguration : EntityBaseTypeConfiguration<Platform, int> {

    protected override void ConfigureEntity(EntityTypeBuilder<Platform> builder) {
      builder.Property(x => x.Name)
          .HasMaxLength(200)
          .IsRequired();
      builder.Property(x => x.NormalizedName)
        .HasMaxLength(250)
        .IsRequired();
    }
  }
}