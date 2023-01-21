using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos
{
    public class InventoryFullView : BaseFullView
    {
        public int Quantity { get; set; }
        public int AlertQuantity { get; set; }
        public int? WarehouseId { get; set; }
        public int? ProductId { get; set; }
    }

    public class InventoryMinimalView : BaseMinimalView
    {
        public int Quantity { get; set; }
        public int AlertQuantity { get; set; }
        public WarehouseMinimalView? Warehouse { get; set; }
        public ProductMinimalView? Product { get; set; }

    }
}
