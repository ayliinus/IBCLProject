using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Asset: BaseEntity
    {
        public string Symbol { get; set; }
        public double LastPrice { get; set; }

    }
}
