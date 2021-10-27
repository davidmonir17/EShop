using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace order.Application.Mapper
{
    public static class OrderMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
         {
             var config = new MapperConfiguration(cfg =>
             {
                 cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                 cfg.AddProfile<OrderMappingProfile>();

             });
             var mapper = config.CreateMapper();
             return mapper;

         }
        );
        public static IMapper mapper => lazy.Value;
    }
}
