using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel;

namespace Business.PortfolioBusiness
{
    public interface IPortfolioBusinessService
    {
        void AddPortfolio(PortfolioVM model);
        List<Portfolio> GetAllPortfolios();
        bool UpdatePortfolio(int PortfolioId, PortfolioVM model);
        bool ProfitCheck(int accountId);
    }
}
