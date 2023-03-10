using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos
{
    public class BrandFullView : BaseFullView
    {
        public string? Name { get; set; }
        public bool IsHidden { get; set; }
        public string? Description { get; set; }
    }

    public class BrandMinimalView : BaseMinimalView
    {
        public string? Name { get; set; }
        public bool IsHidden { get; set; }
    }
}
