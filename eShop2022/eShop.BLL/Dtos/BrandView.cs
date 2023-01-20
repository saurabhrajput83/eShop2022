using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos
{
    public class BrandView : BaseView
    {
        public string? Name { get; set; }
        public bool IsHidden { get; set; }
        public string? Description { get; set; }
    }
}
