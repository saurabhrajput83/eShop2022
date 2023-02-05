using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Entities
{
    public partial class SelectedItem : BaseEntity
    {
        public SelectedItem()
        { }

        public int Quantity { get; set; }
        public int? ShoppingCartId { get; set; }
        public int? ProductId { get; set; }
        public virtual ShoppingCart? ShoppingCart { get; set; }
        public virtual Product? Product { get; set; }
    }
}
