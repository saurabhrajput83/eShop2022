using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos
{
    public class VariationTypeFullView : BaseFullView
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }

    public class VariationTypeMinimalView : BaseMinimalView
    {
        public string? Name { get; set; }
    }
}
