using OperatorPlatform.Data;
using OperatorPlatform.Data.Repositories;

namespace OperatorPlatform.Business
{
    public class TickerBusiness
    {
        private readonly TickerRepository tickerRepository;

        public TickerBusiness(OperatorPlatformDbContext dbContext)
        {
            tickerRepository = new TickerRepository(dbContext);
        }
    }
}
