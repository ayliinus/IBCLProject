using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entity.EnumBase;

namespace Entity
{
    public class Position : BaseEntity
    {
        public Orders Orders  { get; set; } //yapılacak işlem (alım mı? satım mı?)     
        public int? PortfolioId { get; set; } //kişinin hangi portföyüne işlem yapılacaksa ona erişim
        [ForeignKey("PortfolioId")]
        public virtual Portfolio Portfolios { get; set; }
        public double Rate { get; set; } //işlemin gerçekleşeceği oran. (örn: %5 oranında reaksiyon alındı)
        public bool IsActive { get; set; } //işlem gerçekleştiğinde pozisyonu kapatmak.

    }
}
