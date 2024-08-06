using BankingAPI.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingAPI.Data.Configurations
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.HasKey(a => a.Id);
           
            builder
                .Property(a => a.AccountNumber)
                .IsRequired();
            builder
                .Property(a => a.IBAN)
                .IsRequired()
                .HasMaxLength(26)
                .IsFixedLength();

            builder.Property(a => a.AccountName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(a => a.Balance)
                .IsRequired()
                .HasDefaultValue(0);                      
        }
    }
}
