using OperatorPlatform.Data;
using OperatorPlatform.Data.Repositories;

namespace OperatorPlatform.Business
{
    public class ExchangeBusiness
    {
        private readonly ExchangeRepository exchangeRepository;

        public ExchangeBusiness(OperatorPlatformDbContext dbContext)
        {
            exchangeRepository = new ExchangeRepository(dbContext);
        }
    }
}
