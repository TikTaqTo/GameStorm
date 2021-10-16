using GameService.Domain.EntityModels.Dictionaries;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Infrastructure.Persistence.EntityConfigurations.Dictionaries {

  public class TagConfiguration : EntityBaseTypeConfiguration<Tag, int> {

    protected override void ConfigureEntity(EntityTypeBuilder<Tag> builder) {
      builder.Property(x => x.Name)
          .HasMaxLength(200)
          .IsRequired();
      
      builder.Property(x => x.NormalizedName)
        .HasMaxLength(250)
        .IsRequired();

      builder.HasMany(x => x.Games)
        .WithMany(x => x.Tags);
    }
  }
}