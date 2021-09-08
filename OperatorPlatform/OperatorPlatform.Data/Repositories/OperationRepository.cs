using OperatorPlatform.Data.Abstractions;
using OperatorPlatform.Models;

namespace OperatorPlatform.Data.Repositories
{
    public class OperationRepository : GenericRepository<Operation>
    {
        public OperationRepository(OperatorPlatformDbContext dbContext) : base(dbContext)
        {
        }
    }
}
