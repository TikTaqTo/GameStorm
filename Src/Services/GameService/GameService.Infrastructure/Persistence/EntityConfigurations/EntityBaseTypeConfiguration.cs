using GameService.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GameService.Infrastructure.Persistence.EntityConfigurations {

  public abstract class EntityBaseTypeConfiguration<TEntity, TKey> : IEntityTypeConfiguration<TEntity>
   where TEntity : BaseEntity<TKey>
   where TKey : struct {

    public void Configure(EntityTypeBuilder<TEntity> builder) {
      builder.HasKey(x => x.Id);
      builder.Property(x => x.CreatedAt)
          .ValueGeneratedOnAdd()
          .IsRequired();
      builder.Property(x => x.CreatedBy)
          .HasDefaultValue("admin")
          .IsRequired();
      builder.Property(x => x.ModifiedAt)
          .ValueGeneratedOnUpdate()
          .IsRequired();

      ConfigureEntity(builder);
    }

    protected abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
  }
}