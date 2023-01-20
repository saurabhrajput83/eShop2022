using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShop.BLL.AutoMapper
{
    public static class AutoMapperConfiguration
    {
        private static MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(mc =>
            {
                mc.AddMaps("eShop.BLL", "eShop.DAL");
            });
        }

        public static IMapper Configure()
        {
            var mapperConfiguration = GetMapperConfiguration();
            return mapperConfiguration.CreateMapper();
        }

    }
}
