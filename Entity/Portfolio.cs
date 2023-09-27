using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class Portfolio : BaseEntity
    {
        public int AssetId { get; set; } //hangi coini aldığım
        [ForeignKey("AssetId")]
        public virtual Asset Assets { get; set; }
        public int AccountId { get; set; } //hangi hesabın portföy'ü
        [ForeignKey("AccountId")]
        public virtual Account Accounts { get; set; }
        public double PurchasePrice { get; set; } //fiyat olarak ne kadara satın aldığım
        public double Quantity { get; set; } //ne kadar aldığım (miktar olarak)
        public bool IsActive { get; set; } //güncel ve aktif olan satın almalar. 
        public virtual ICollection<Position> Positions { get; set; }


    }
}
