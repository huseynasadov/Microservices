using AutoMapper;
using EventBusRabbitMq.Events;
using Ordering.Application.Commands;
using Ordering.Application.Responses;
using Ordering.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ordering.Application.Mapper
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderResponse>();
            CreateMap<CheckoutOrderCommand, Order>();
            CreateMap<OrderResponse, OrderCheckoutEvent>();
        }
    }
}
