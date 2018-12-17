using AutoMapper;
using CartBackend.Common.DTO;
using CartBackend.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CartBackend.Configuration
{
    public static class AutoMapperCfg
    {
        public static IMapper GetProductMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<ProductDTO, Product>());

            return config.CreateMapper();
        }
    }
}
