using BankingAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingAPI.Data.Configurations
{
    public class CreditCardConfiguration : IEntityTypeConfiguration<CreditCard>
    {
        public void Configure(EntityTypeBuilder<CreditCard> builder)
        {
            builder.HasIndex(c => c.CardNumber)
                .IsUnique();
            builder.Property(p => p.CardNumber)
                .HasMaxLength(16)
                .IsFixedLength()
                .IsRequired();

            builder.Property(p => p.CVV)
                .HasMaxLength(3)
                .IsFixedLength()
                .IsRequired();           
        }
    }
}
