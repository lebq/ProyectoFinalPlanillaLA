using Galaxy.Bank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Galaxy.Bank.Persistence.Configuration.Entities
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers", schema: "Bank");

            builder.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("name");

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(100)
                .HasColumnName("last_name");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("email");

            builder.Property(c => c.Address)
                .IsRequired()
                .HasMaxLength(200)
                .HasColumnName("address");

            builder.Property(c => c.BornDate)
                .IsRequired()
                .HasColumnName("born_date");

            builder.OwnsOne(c => c.Document, doc =>
            {
                doc.Property(d => d.Number)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("document_number");

                doc.Property(d => d.Type)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("document_type");

                doc.HasIndex(d => new { d.Type, d.Number })
                    .IsUnique()
                    .HasDatabaseName("IX_Customers_Document_Type_Number");
            });


            builder.HasMany(cp => cp.Loans)
                .WithOne(l => l.Customer)
                .HasForeignKey(l => l.CustomerId)
                .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
