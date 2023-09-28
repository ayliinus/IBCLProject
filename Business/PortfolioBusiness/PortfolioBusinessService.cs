using Context;
using Entity;
using Microsoft.EntityFrameworkCore;
using Repository.AccountRepository;
using Repository.PortfolioRepository;
using System.Text.Json;
using ViewModel;

namespace Business.PortfolioBusiness
{
    public class PortfolioBusinessService : IPortfolioBusinessService
    {
        private readonly ApplicationDbContext _context;
        private readonly IPortfolioRepositoryService _portfolioRepository;
        private readonly IAccountRepositoryService _accountRepository;
        public PortfolioBusinessService(IPortfolioRepositoryService portfolioRepository, ApplicationDbContext context, IAccountRepositoryService accountRepository)
        {
            _context = context;
            _portfolioRepository = portfolioRepository;
            _accountRepository = accountRepository;
        }

        public void AddPortfolio(PortfolioVM model)
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
                        Quantity = model.Quantity,
                        IsActive = true
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

        public List<Portfolio> GetAllPortfolios()
        {

            var result = _portfolioRepository.Get(w => w.CreatedAt != null).ToList();
            return result;

        }

        public bool UpdatePortfolio(int PortfolioId, PortfolioVM model)
        {
            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var existingPortfolio = _portfolioRepository.GetFirst(w => w.Id == PortfolioId);
                    if (existingPortfolio == null)
                    {
                        return false;
                    }

                    existingPortfolio.AssetId = model.AssetId;
                    existingPortfolio.AccountId = model.AccountId;
                    existingPortfolio.PurchasePrice = model.PurchasePrice;
                    existingPortfolio.Quantity = model.Quantity;

                    _portfolioRepository.Update(existingPortfolio);

                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw;
                }
                return true;
            }
        }
        public bool ProfitCheck(int accountId)
        {
            var getUserRate = _accountRepository.GetFirst(e => e.Id == accountId).NotificationRate;
            var users = _portfolioRepository.Get(w => w.AccountId == accountId && w.IsActive).Include(i=> i.Assets).ToList();

            using (HttpClient httpClient = new HttpClient())
            {
               
                var response = httpClient.GetAsync("https://www.binance.me/api/v3/ticker/price?symbols=%5B%22ETHUSDT%22,%22BTCUSDT%22,%22AVAXUSDT%22%5D").Result;

                var content = response.Content.ReadAsStringAsync().Result;
                var assetDto = JsonSerializer.Deserialize<List<AssetVM>>(content);

                foreach (var user in users)
                {
                    var assetInfo = assetDto.FirstOrDefault(a => a.symbol == user.Assets.Symbol);
                    if (assetInfo != null)
                    {
                        var current = user.PurchasePrice;
                        var newPrice = Convert.ToDouble(assetInfo.price);
                        var percentageProfit = ((newPrice - current) / current) * 100;
                        
                        if (getUserRate == percentageProfit)
                        {
                            return true;
                        }
                    }
                }

           
                return false;
            }
        }

    }
}
