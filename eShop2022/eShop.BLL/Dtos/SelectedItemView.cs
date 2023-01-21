using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos
{
    public class SelectedItemFullView : BaseFullView
    {
        public int Quantity { get; set; }
        public int? ShoppingCartId { get; set; }
        public int? ProductId { get; set; }
    }

    public class SelectedItemMinimalView : BaseMinimalView
    {
        public int Quantity { get; set; }
        public ShoppingCartView? ShoppingCart { get; set; }
        public ProductMinimalView? Product { get; set; }
    }
}
