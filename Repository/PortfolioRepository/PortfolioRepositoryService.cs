using Context;
using Entity;


namespace Repository.PortfolioRepository
{
    public class PortfolioRepositoryService : BaseRepository<Portfolio>, IPortfolioRepositoryService
    {
        public PortfolioRepositoryService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
