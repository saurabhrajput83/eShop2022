using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Entities
{
    public partial class Department : BaseEntity
    {
        public Department()
        {
            DepartmentProducts= new HashSet<DepartmentProduct>();
        }

        public string? Name { get; set; }
        public bool IsHidden { get; set; }
        public string? Description { get; set; }
        public int? ParentId { get; set; }
        public virtual Department? Parent { get; set; }
        public virtual ICollection<DepartmentProduct> DepartmentProducts { get; set; }

    }
}
