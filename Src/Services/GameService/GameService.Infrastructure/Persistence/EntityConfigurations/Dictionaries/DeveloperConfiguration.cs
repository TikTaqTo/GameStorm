using GameService.Domain.EntityModels.Dictionaries;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameService.Infrastructure.Persistence.EntityConfigurations.Dictionaries {

  public class DeveloperConfiguration : EntityBaseTypeConfiguration<Developer, int> {

    protected override void ConfigureEntity(EntityTypeBuilder<Developer> builder) {
      builder.Property(x => x.SeoTitle)
          .HasMaxLength(200)
          .IsRequired();
      builder.Property(x => x.NormalizedSeoTitle)
        .HasMaxLength(250)
        .IsRequired();
      builder.HasMany(x => x.CreatedGames)
        .WithMany(x => x.Developers);

    }
  }
}