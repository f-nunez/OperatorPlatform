using Microsoft.EntityFrameworkCore;

namespace OperatorPlatform.Data
{
    public class OperatorPlatformDbContext : DbContext
    {
        public string ConnectionString { get; set; }
        #region DbSets
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
        }
    }
}
