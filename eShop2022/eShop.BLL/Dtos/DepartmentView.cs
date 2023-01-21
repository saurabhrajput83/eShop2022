using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos
{
    public class DepartmentFullView : BaseFullView
    {
        public string? Name { get; set; }
        public bool IsHidden { get; set; }
        public string? Description { get; set; }
        public int? ParentId { get; set; }

    }

    public class DepartmentMinimalView : BaseMinimalView
    {
        public string? Name { get; set; }
        public bool IsHidden { get; set; }
        public virtual DepartmentMinimalView? Parent { get; set; }

    }
}
