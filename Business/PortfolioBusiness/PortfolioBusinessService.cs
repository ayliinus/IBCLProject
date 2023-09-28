using Context;
using Entity;
using Repository.PortfolioRepository;
using ViewModel;

namespace Business.PortfolioBusiness
{
    public class PortfolioBusinessService : IPortfolioBusinessService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPortfolioRepositoryService _portfolioRepository;
        public PortfolioBusinessService(IPortfolioRepositoryService portfolioRepository, ApplicationDbContext context)
        {
            _context = context;
            _portfolioRepository = portfolioRepository;
        }

        public void AddPortfolio(PortfolioCreateVM model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var newPortfolio = new Portfolio
                    {
                        AssetId = model.AssetId,
                        AccountId = model.AccountId,
                        PurchasePrice = model.PurchasePrice,
                        Quantity = model.Quantity
                    };

                    _portfolioRepository.Add(newPortfolio);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
}
