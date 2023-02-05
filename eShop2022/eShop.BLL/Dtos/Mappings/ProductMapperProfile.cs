using AutoMapper;
using eShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos.Mappings
{
    public class ProductMapperProfile : Profile
    {
        public ProductMapperProfile()
        {
            CreateMap<ProductFullView, Product>()
                    .ReverseMap();
            CreateMap<ProductMinimalView, Product>()
                   .ReverseMap();
        }
    }
}
