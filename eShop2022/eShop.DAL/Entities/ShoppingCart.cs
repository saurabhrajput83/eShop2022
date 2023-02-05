using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Entities
{
    public partial class ShoppingCart : BaseEntity
    {
        public ShoppingCart()
        { }

        public int? CustomerId { get; set; }
    }
}
