using OperatorPlatform.Data;
using OperatorPlatform.Data.Repositories;

namespace OperatorPlatform.Business
{
    public class OperationBusiness
    {
        private readonly OperationRepository operationRepository;

        public OperationBusiness(OperatorPlatformDbContext dbContext)
        {
            operationRepository = new OperationRepository(dbContext);
        }
    }
}
