using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entity.EnumBase;

namespace ViewModel
{
    public class PositionVM
    {
        public Orders Orders { get; set; }  
        public int? PortfolioId { get; set; } 
        public double Rate { get; set; } 
        public bool IsActive { get; set; } 
    }
}
