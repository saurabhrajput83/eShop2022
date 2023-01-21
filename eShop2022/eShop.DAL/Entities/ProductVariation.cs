using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Entities
{
    public class ProductVariation : BaseEntity
    {
        public double PriceModifier { get; set; }
        public int Quantity { get; set; }
        public bool IsHidden { get; set; }
        public int? ProductId { get; set; }
        public int? VariationId { get; set; }
        public Product? Product { get; set; }
        public Variation? Variation { get; set; }
    }
}
