using AutoMapper;
using eShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos.Mappings
{
    public class WarehouseMapperProfile : Profile
    {
        public WarehouseMapperProfile()
        {
            CreateMap<WarehouseFullView, Warehouse>()
                    .ReverseMap();
            CreateMap<WarehouseMinimalView, Warehouse>()
                   .ReverseMap();
        }
    }
}
