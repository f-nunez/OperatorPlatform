using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OperatorPlatform.Models;

namespace OperatorPlatform.Mappings
{
    public class AlertMapping : IEntityTypeConfiguration<Alert>
    {
        private const int MaximumLength = 30;
        public void Configure(EntityTypeBuilder<Alert> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder.HasOne(x => x.Indicator)
                .WithMany(y => y.Alerts)
                .HasForeignKey(x => x.IndicatorId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Ticker)
                .WithMany(y => y.Alerts)
                .HasForeignKey(x => x.TickerId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.Property(x => x.Description)
                .HasMaxLength(MaximumLength);
        }
    }
}
