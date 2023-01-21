using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos
{
    public class ProductImageView : BaseFullView
    {
        public string? ImageUrl { get; set; }
        public string? AltTag { get; set; }
        public bool IsDefault { get; set; }
        public int? ProductId { get; set; }

    }

}
