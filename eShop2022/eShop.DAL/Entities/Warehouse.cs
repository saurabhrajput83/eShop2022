using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Entities
{
    public partial class Warehouse : BaseEntity
    {
        public Warehouse()
        { }

        public string? Name { get; set; }
        public bool IsHidden { get; set; }
        public string? Description { get; set; }
        public string? Url { get; set; }

    }
}
