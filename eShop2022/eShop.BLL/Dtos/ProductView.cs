using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos
{
    public class ProductFullView : BaseFullView
    {
        public string? Name { get; set; }
        public bool IsHidden { get; set; }
        public string? ModelNumber { get; set; }
        public string? Summary { get; set; }
        public string? Description { get; set; }
        public decimal ListPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string? InfoUrl { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsActive { get; set; }
        public bool IsTaxable { get; set; }
        public bool HasFreeShipping { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Breadth { get; set; }
        public decimal Height { get; set; }
        public int BrandId { get; set; }
    }

    public class ProductMinimalView : BaseMinimalView
    {
        public string? Name { get; set; }
        public string? ModelNumber { get; set; }
        public decimal ListPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public string? InfoUrl { get; set; }
        public string? ImageUrl { get; set; }
    }

}