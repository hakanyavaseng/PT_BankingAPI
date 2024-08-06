using BankingAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingAPI.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.HasIndex(c => c.TCNumber)
                .IsUnique();

            builder.Property(c => c.TCNumber)
                .IsRequired()
                .HasMaxLength(11)
                .IsFixedLength();

            builder.Property(c => c.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.BirthPlace)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(c => c.BirthDate)
                .IsRequired();

            builder.Property(c => c.RiskLimit)
                .IsRequired()
                .HasColumnType("decimal(18,2)")
                .HasDefaultValue(10000.00m);

            builder.Property(c => c.BirthDate)
                .HasColumnType("date");
        }

    }
}