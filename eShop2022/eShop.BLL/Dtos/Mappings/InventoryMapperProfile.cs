using AutoMapper;
using eShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos.Mappings
{
    public class InventoryMapperProfile : Profile
    {
        public InventoryMapperProfile()
        {
            CreateMap<InventoryFullView, Inventory>()
                    .ReverseMap();
            CreateMap<InventoryMinimalView, Inventory>()
                   .ReverseMap();
        }
    }
}
