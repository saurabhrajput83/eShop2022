using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos
{
    public class DepartmentProductView : BaseFullView
    {
        public int? DepartmentId { get; set; }
        public int? ProductId { get; set; }
    }
}
