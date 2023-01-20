using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Entities
{
    public class Variation : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public bool IsHidden { get; set; }
        public int VariationTypeId { get; set; }
        public VariationType? VariationType { get; set; }
    }
}
