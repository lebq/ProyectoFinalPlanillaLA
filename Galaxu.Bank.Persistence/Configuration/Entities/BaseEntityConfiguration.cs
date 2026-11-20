using Galaxy.Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Galaxy.Bank.Persistence.Configuration.Entities
{
    public class BaseEntityConfiguration<TEntity> : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
    {
        public virtual void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(p => p.CreatedAt).IsRequired();
            builder.Property(p => p.CreatedBy).IsRequired();
            builder.Property(p => p.UpdatedAt).IsRequired(false);
            builder.Property(p => p.UpdatedBy).IsRequired(false);
        }
    }
}
