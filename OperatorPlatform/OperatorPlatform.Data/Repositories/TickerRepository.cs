using OperatorPlatform.Data.Abstractions;
using OperatorPlatform.Models;

namespace OperatorPlatform.Data.Repositories
{
    public class TickerRepository : GenericRepository<Ticker>
    {
        public TickerRepository(OperatorPlatformDbContext dbContext) : base(dbContext)
        {
        }
    }
}
