using Galaxy.Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Galaxy.Bank.Persistence.Configuration.Entities
{
    public class LoanConfiguration : IEntityTypeConfiguration<Loan>
    {
        public void Configure(EntityTypeBuilder<Loan> builder)
        {
            builder.ToTable("Loans", schema: "Bank");

            builder.Property(l => l.CustomerId)
                .IsRequired()
                .HasColumnName("customer_id");

            builder.Property(l => l.CreditProductId)
                .IsRequired()
                .HasColumnName("credit_product_id");

            builder.OwnsOne(l => l.Amount, a =>
            {
                a.Property(m => m.Amount)
                    .IsRequired()
                    .HasColumnName("amount");

                a.Property(m => m.Currency)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("currency");
            });

            builder.OwnsOne(l => l.Term, t =>
            {
                t.Property(lt => lt.Months)
                    .IsRequired()
                    .HasColumnName("term_months");
            });

            builder.OwnsOne(l => l.InterestRate, ir =>
            {
                ir.Property(i => i.Value)
                    .IsRequired()
                    .HasPrecision(5, 4)
                    .HasColumnName("interest_rate");
            });

            builder.Property(l => l.Status)
                .IsRequired()
                .HasColumnName("status");

            builder.Property(l => l.ReasonStatus)
                .HasMaxLength(500)
                .HasColumnName("reason_status");

            builder.HasOne(l => l.Customer)
                .WithMany(c => c.Loans)
                .HasForeignKey(l => l.CustomerId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(l => l.CreditProduct)
                .WithMany(cp => cp.Loans)
                .HasForeignKey(l => l.CreditProductId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(l => l.Payments)
                .WithOne(p => p.Loan)
                .HasForeignKey(p => p.LoanId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(l => l.CustomerId)
                .HasDatabaseName("IX_Loans_CustomerId");

            builder.HasIndex(l => l.CreditProductId)
                .HasDatabaseName("IX_Loans_CreditProductId");
        }
    }
}
