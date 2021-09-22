using OperatorPlatform.Data;
using OperatorPlatform.Data.Repositories;

namespace OperatorPlatform.Business
{
    public class IndicatorBusiness
    {
        private readonly IndicatorRepository indicatorRepository;

        public IndicatorBusiness(OperatorPlatformDbContext dbContext)
        {
            indicatorRepository = new IndicatorRepository(dbContext);
        }
    }
}
