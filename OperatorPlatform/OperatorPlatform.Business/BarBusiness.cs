using OperatorPlatform.Data;
using OperatorPlatform.Data.Repositories;

namespace OperatorPlatform.Business
{
    public class BarBusiness
    {
        private readonly BarRepository barRepository;

        public BarBusiness(OperatorPlatformDbContext dbContext)
        {
            barRepository = new BarRepository(dbContext);
        }
    }
}
