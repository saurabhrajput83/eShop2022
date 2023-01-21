using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
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
        public double ListPrice { get; set; }
        public double SellingPrice { get; set; }
        public string? InfoUrl { get; set; }
        public string? ImageUrl { get; set; }
        public bool IsFeatured { get; set; }
        public bool IsActive { get; set; }
        public bool IsTaxable { get; set; }
        public bool HasFreeShipping { get; set; }
        public double Weight { get; set; }
        public double Length { get; set; }
        public double Breadth { get; set; }
        public double Height { get; set; }
        public int BrandId { get; set; }
    }

    public class ProductMinimalView : BaseMinimalView
    {
        public string? Name { get; set; }
        public string? ModelNumber { get; set; }
        public double ListPrice { get; set; }
        public double SellingPrice { get; set; }
        public string? InfoUrl { get; set; }
        public string? ImageUrl { get; set; }
    }

}