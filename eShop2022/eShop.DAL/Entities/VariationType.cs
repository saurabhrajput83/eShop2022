using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Entities
{
    public class VariationType : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
    }
}
