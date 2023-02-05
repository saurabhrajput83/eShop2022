using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Entities
{
    public partial class ProductVariation : BaseEntity
    {
        public ProductVariation()
        { }

        public double PriceModifier { get; set; }
        public int Quantity { get; set; }
        public bool IsHidden { get; set; }
        public int? ProductId { get; set; }
        public int? VariationId { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Variation? Variation { get; set; }
    }
}
