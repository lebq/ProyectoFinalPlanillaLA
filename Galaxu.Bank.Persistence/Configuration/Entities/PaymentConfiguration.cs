using Galaxy.Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Galaxy.Bank.Persistence.Configuration.Entities
{
    public class PaymentConfiguration : IEntityTypeConfiguration<Payment>
    {
        public void Configure(EntityTypeBuilder<Payment> builder)
        {
            builder.ToTable("Payments", schema: "Bank");

            builder.Property(p => p.LoanId)
                .IsRequired()
                .HasColumnName("loan_id");

            builder.Property(p => p.Number)
                .IsRequired()
                .HasColumnName("number");

            builder.Property(p => p.DueDate)
                .IsRequired()
                .HasColumnName("due_date");

            builder.OwnsOne(p => p.Amount, a =>
            {
                a.Property(m => m.Amount)
                    .IsRequired()
                    .HasColumnName("amount");

                a.Property(m => m.Currency)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("currency");
            });

            builder.OwnsOne(p => p.Interest, i =>
            {
                i.Property(m => m.Amount)
                    .IsRequired()
                    .HasColumnName("interest");

                i.Property(m => m.Currency)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("interest_currency");
            });

            builder.Property(p => p.Status)
                .IsRequired()
                .HasColumnName("status");

            builder.Property(p => p.PaymentDate)
                .HasColumnName("payment_date");

            builder.OwnsOne(p => p.PaidAmount, pa =>
            {
                pa.Property(m => m.Amount)
                    .IsRequired()
                    .HasColumnName("paid_amount");

                pa.Property(m => m.Currency)
                    .IsRequired()
                    .HasMaxLength(3)
                    .HasColumnName("paid_amount_currency");
            });

            builder.HasOne(p => p.Loan)
                .WithMany(l => l.Payments)
                .HasForeignKey(p => p.LoanId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasIndex(p => p.LoanId)
                .HasDatabaseName("IX_Payments_LoanId");

            builder.HasIndex(p => new { p.LoanId, p.Number })
                .IsUnique()
                .HasDatabaseName("IX_Payments_LoanId_Number");
        }
    }
}
