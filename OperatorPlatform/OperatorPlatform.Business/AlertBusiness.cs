using OperatorPlatform.Data;
using OperatorPlatform.Data.Repositories;

namespace OperatorPlatform.Business
{
    public class AlertBusiness
    {
        private readonly AlertRepository alertRepository;

        public AlertBusiness(OperatorPlatformDbContext dbContext)
        {
            alertRepository = new AlertRepository(dbContext);
        }
    }
}
