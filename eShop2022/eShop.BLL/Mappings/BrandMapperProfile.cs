using AutoMapper;
using eShop.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.Dtos
{
    public class BrandMapperProfile : Profile
    {
        public BrandMapperProfile()
        {
            CreateMap<BrandFullView, Brand>()
                    .ReverseMap();
            CreateMap<BrandMinimalView, Brand>()
                   .ReverseMap();
        }
    }
}
