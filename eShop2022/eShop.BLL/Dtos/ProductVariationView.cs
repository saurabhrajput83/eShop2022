using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos
{
    public class ProductVariationFullView : BaseFullView
    {
        public decimal PriceModifier { get; set; }
        public int Quantity { get; set; }
        public bool IsHidden { get; set; }
        public int? ProductId { get; set; }
        public int? VariationId { get; set; }
    }

    public class ProductVariationMinimalView : BaseMinimalView
    {
        public decimal PriceModifier { get; set; }
        public int Quantity { get; set; }
        public bool IsHidden { get; set; }
        public ProductMinimalView? Product { get; set; }
        public VariationMinimalView? Variation { get; set; }
    }
}
