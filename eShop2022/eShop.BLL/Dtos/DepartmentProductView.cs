using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos
{
    public class DepartmentProductFullView : BaseFullView
    {
        public int? DepartmentId { get; set; }
        public int? ProductId { get; set; }
    }

    public class DepartmentProductMinimalView : BaseMinimalView
    {
        public DepartmentMinimalView? Department { get; set; }
        public ProductMinimalView? Product { get; set; }
    }
}
