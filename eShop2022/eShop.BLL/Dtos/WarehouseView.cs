using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos
{
    public class WarehouseFullView : BaseFullView
    {
        public string? Name { get; set; }
        public bool IsHidden { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }

    }

    public class WarehouseMinimalView : BaseMinimalView
    {
        public string? Name { get; set; }
        public bool IsHidden { get; set; }

    }
}
