using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos
{
    public class VariationFullView : BaseFullView
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsHidden { get; set; }
        public int? VariationTypeId { get; set; }
    }

    public class VariationMinimalView : BaseMinimalView
    {
        public string? Name { get; set; }
        public bool IsHidden { get; set; }
        public VariationTypeMinimalView? VariationType { get; set; }
    }
}
