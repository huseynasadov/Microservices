using AutoMapper;
using Basket.Api.Entities;
using EventBusRabbitMq.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BasketCheckout, OrderCheckoutEvent>();
        }
    }
}
