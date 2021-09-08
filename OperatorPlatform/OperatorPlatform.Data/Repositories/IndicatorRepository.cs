using OperatorPlatform.Data.Abstractions;
using OperatorPlatform.Models;

namespace OperatorPlatform.Data.Repositories
{
    public class IndicatorRepository : GenericRepository<Indicator>
    {
        public IndicatorRepository(OperatorPlatformDbContext dbContext) : base(dbContext)
        {
        }
    }
}
