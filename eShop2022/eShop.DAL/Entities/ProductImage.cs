using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.DAL.Entities
{
    public partial class ProductImage : BaseEntity
    {
        public ProductImage()
        { }

        public string? ImageUrl { get; set; }
        public string? AltTag { get; set; }
        public bool IsDefault { get; set; }
        public int? ProductId { get; set; }
        public virtual Product? Product { get; set; }

    }
}
