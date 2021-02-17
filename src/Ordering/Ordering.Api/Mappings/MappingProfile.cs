using AutoMapper;
using EventBusRabbitMq.Events;
using Ordering.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ordering.Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderResponse, OrderCheckoutEvent>();
        }
    }
}
