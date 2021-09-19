using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperatorPlatform.Models;

namespace OperatorPlatform.Mappings
{
    public class BarMapping : IEntityTypeConfiguration<Bar>
    {
        private const int MaximumNumberOfDigits = 17;
        private const int MaximumNumberOfDecimalPlaces = 8;

        public void Configure(EntityTypeBuilder<Bar> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Ticker)
                .WithMany(y => y.Bars)
                .HasForeignKey(x => x.TickerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.BollingerLowerBandFirst)
                .HasPrecision(MaximumNumberOfDigits, MaximumNumberOfDecimalPlaces);
            builder.Property(x => x.BollingerLowerBandSecond)
                .HasPrecision(MaximumNumberOfDigits, MaximumNumberOfDecimalPlaces);
            builder.Property(x => x.BollingerLowerBandThird)
                .HasPrecision(MaximumNumberOfDigits, MaximumNumberOfDecimalPlaces);
            builder.Property(x => x.BollingerUpperBandFirst)
                .HasPrecision(MaximumNumberOfDigits, MaximumNumberOfDecimalPlaces);
            builder.Property(x => x.BollingerUpperBandSecond)
                .HasPrecision(MaximumNumberOfDigits, MaximumNumberOfDecimalPlaces);
            builder.Property(x => x.BollingerUpperBandThird)
                .HasPrecision(MaximumNumberOfDigits, MaximumNumberOfDecimalPlaces);
            builder.Property(x => x.Close)
                .HasPrecision(MaximumNumberOfDigits, MaximumNumberOfDecimalPlaces);
            builder.Property(x => x.High)
                .HasPrecision(MaximumNumberOfDigits, MaximumNumberOfDecimalPlaces);
            builder.Property(x => x.Low)
                .HasPrecision(MaximumNumberOfDigits, MaximumNumberOfDecimalPlaces);
            builder.Property(x => x.Open)
                .HasPrecision(MaximumNumberOfDigits, MaximumNumberOfDecimalPlaces);
            builder.Property(x => x.MovingAverage)
                .HasPrecision(MaximumNumberOfDigits, MaximumNumberOfDecimalPlaces);
        }
    }
}
