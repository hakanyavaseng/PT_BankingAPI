using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankingAPI.Data.Configurations
{
    public class DebitCardConfiguration : IEntityTypeConfiguration<DebitCard>
    {
        public void Configure(EntityTypeBuilder<DebitCard> builder)
        {
            builder.Property(p => p.ExpiryDate)
                .HasColumnType("date");
        }
    }
}
