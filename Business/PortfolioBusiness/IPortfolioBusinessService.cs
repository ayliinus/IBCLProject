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
        void AddPortfolio(PortfolioCreateVM model);
    }
}
