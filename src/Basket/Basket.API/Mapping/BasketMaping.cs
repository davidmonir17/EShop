using AutoMapper;
using Basket.API.Entities;
using EventBusRabbitMQ.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.API.Mapping
{
    public class BasketMaping : Profile
    {
        public BasketMaping()
        {
            CreateMap<BasketCheckoout, BasketCheckoutEvent>().ReverseMap();
        }
    }
}
