using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel
{
    public class PortfolioCreateVM
    {
        public int AssetId { get; set; }
        public int AccountId { get; set; } 
        public double PurchasePrice { get; set; } 
        public double Quantity { get; set; } 
    }
}
