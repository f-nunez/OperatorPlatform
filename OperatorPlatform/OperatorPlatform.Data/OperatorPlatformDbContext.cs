using Microsoft.EntityFrameworkCore;
using OperatorPlatform.Mappings;
using OperatorPlatform.Models;

namespace OperatorPlatform.Data
{
    public class OperatorPlatformDbContext : DbContext
    {
        public string ConnectionString { get; set; }
        #region DbSets
        public DbSet<Alert> Alerts { get; set; }
        public DbSet<Bar> Bars { get; set; }
        public DbSet<Exchange> Exchanges { get; set; }
        public DbSet<Indicator> Indicators { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<Ticker> Tickers { get; set; }
        #endregion
        public OperatorPlatformDbContext(DbContextOptions<OperatorPlatformDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
            {
                dbContextOptionsBuilder.UseSqlServer(ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new AlertMapping());
            modelBuilder.ApplyConfiguration(new BarMapping());
            modelBuilder.ApplyConfiguration(new ExchangeMapping());
            modelBuilder.ApplyConfiguration(new IndicatorMapping());
            modelBuilder.ApplyConfiguration(new OperationMapping());
            modelBuilder.ApplyConfiguration(new TickerMapping());
        }
    }
}
