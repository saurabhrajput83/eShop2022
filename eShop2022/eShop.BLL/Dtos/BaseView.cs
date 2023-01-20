using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos
{
    public class BaseView
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
    }
}
