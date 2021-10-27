using AutoMapper;
using order.Application.Command;
using order.Application.Responses;
using order.core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace order.Application.Mapper
{
    class OrderMappingProfile: Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderResponse>().ReverseMap();
            CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
        }
    }
}
