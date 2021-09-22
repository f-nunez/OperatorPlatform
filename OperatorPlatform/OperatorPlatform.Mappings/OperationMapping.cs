using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperatorPlatform.Models;

namespace OperatorPlatform.Mappings
{
    public class OperationMapping : IEntityTypeConfiguration<Operation>
    {
        private const int MaximumNumberOfDigits = 17;
        private const int MaximumNumberOfDecimalPlaces = 8;

        public void Configure(EntityTypeBuilder<Operation> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Alert)
                .WithMany(y => y.Operations)
                .HasForeignKey(x => x.AlertId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Bar)
                .WithMany(y => y.Operations)
                .HasForeignKey(x => x.BarId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Ticker)
                .WithMany(y => y.Operations)
                .HasForeignKey(x => x.TickerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.Amount)
                .HasPrecision(MaximumNumberOfDigits, MaximumNumberOfDecimalPlaces);
            builder.Property(x => x.Price)
                .HasPrecision(MaximumNumberOfDigits, MaximumNumberOfDecimalPlaces);
            builder.Property(x => x.StopLoss)
                .HasPrecision(MaximumNumberOfDigits, MaximumNumberOfDecimalPlaces);
            builder.Property(x => x.StopProfit)
                .HasPrecision(MaximumNumberOfDigits, MaximumNumberOfDecimalPlaces);
            builder.Property(x => x.Total)
                .HasPrecision(MaximumNumberOfDigits, MaximumNumberOfDecimalPlaces);
        }
    }
}
