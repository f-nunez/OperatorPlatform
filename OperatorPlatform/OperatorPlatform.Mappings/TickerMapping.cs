using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperatorPlatform.Models;

namespace OperatorPlatform.Mappings
{
    public class TickerMapping : IEntityTypeConfiguration<Ticker>
    {
        public void Configure(EntityTypeBuilder<Ticker> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Exchange)
                .WithMany(y => y.Tickers)
                .HasForeignKey(x => x.ExchangeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
