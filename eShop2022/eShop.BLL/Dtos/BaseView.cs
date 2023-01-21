using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos
{
    public class BaseFullView
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public string? CreatedBy { get; set; }
        public string? ModifiedBy { get; set; }
    }

    public class BaseMinimalView
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
    }
}
