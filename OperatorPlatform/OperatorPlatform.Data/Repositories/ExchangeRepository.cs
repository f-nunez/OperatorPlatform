using OperatorPlatform.Data.Abstractions;
using OperatorPlatform.Models;

namespace OperatorPlatform.Data.Repositories
{
    public class ExchangeRepository : GenericRepository<Exchange>
    {
        public ExchangeRepository(OperatorPlatformDbContext dbContext) : base(dbContext)
        {
        }
    }
}
