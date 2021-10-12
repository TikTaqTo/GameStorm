using GameService.Domain.EntityModels.Media;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameService.Infrastructure.Persistence.EntityConfigurations.Media {

  public class ImageConfiguration : EntityBaseTypeConfiguration<Image, Guid> {

    protected override void ConfigureEntity(EntityTypeBuilder<Image> builder) {
      builder.Property(x => x.Name)
          .HasMaxLength(30)
          .IsRequired();
    }
  }
}