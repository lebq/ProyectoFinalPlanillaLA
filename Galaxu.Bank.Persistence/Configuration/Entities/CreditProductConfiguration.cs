using Galaxy.Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Galaxy.Bank.Persistence.Configuration.Entities
{
    public class CreditProductConfiguration : IEntityTypeConfiguration<CreditProduct>
    {
        public void Configure(EntityTypeBuilder<CreditProduct> builder)
        {
            builder.ToTable("CreditProducts", schema: "Bank");

            builder.Property(cp => cp.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name");

            builder.Property(cp => cp.Description)
                .IsRequired()
                .HasMaxLength(500)
                .HasColumnName("description");

            builder.Property(cp => cp.MiniumTerm)
                .IsRequired()
                .HasColumnName("minimum_term");

            builder.Property(cp => cp.MaximumTerm)
                .IsRequired()
                .HasColumnName("maximum_term");

            builder.OwnsOne(cp => cp.MinimumAmount, ma =>
            {
                ma.Property(m => m.Amount)
                    .IsRequired()
                    .HasColumnName("minimum_amount");

                ma.Property(m => m.Currency)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("minimum_amount_currency");
            });

            builder.OwnsOne(cp => cp.MaximumAmount, ma =>
            {
                ma.Property(m => m.Amount)
                    .IsRequired()
                    .HasColumnName("maximum_amount");

                ma.Property(m => m.Currency)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("maximum_amount_currency");
            });

            builder.OwnsOne(cp => cp.AnnualInterestRate, ir =>
            {
                ir.Property(i => i.Value)
                    .IsRequired()
                    .HasPrecision(5, 4)
                    .HasColumnName("annual_interest_rate");
            });

            builder.HasIndex(cp => cp.Name)
                .IsUnique()
                .HasDatabaseName("IX_CreditProducts_Name");

            builder.HasMany(cp => cp.Loans)
                .WithOne(l => l.CreditProduct)
                .HasForeignKey(l => l.CreditProductId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
