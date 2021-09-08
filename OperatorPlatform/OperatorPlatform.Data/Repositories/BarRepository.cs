using OperatorPlatform.Data.Abstractions;
using OperatorPlatform.Models;

namespace OperatorPlatform.Data.Repositories
{
    public class BarRepository : GenericRepository<Bar>
    {
        public BarRepository(OperatorPlatformDbContext dbContext) : base(dbContext)
        {
        }
    }
}
