using OperatorPlatform.Data.Abstractions;
using OperatorPlatform.Models;

namespace OperatorPlatform.Data.Repositories
{
    public class AlertRepository : GenericRepository<Alert>
    {
        public AlertRepository(OperatorPlatformDbContext dbContext) : base(dbContext)
        {
        }
    }
}
