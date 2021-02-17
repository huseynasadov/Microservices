using EventBusRabbitMq.Common;
using EventBusRabbitMq.Events;
using EventBusRabbitMq.Producer;
using MediatR;
using Ordering.Application.Commands;
using Ordering.Application.Mapper;
using Ordering.Application.Responses;
using Ordering.Core.Entities;
using Ordering.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Handles
{
    public class CheckoutOrderHandler : IRequestHandler<CheckoutOrderCommand, OrderResponse>
    {
        private readonly IOrderRepository _order;
        private readonly EventBusRabbitMQProducer _eventBus;

        public CheckoutOrderHandler(IOrderRepository order, EventBusRabbitMQProducer eventBus)
        {
            _order = order;
            _eventBus = eventBus;
        }

        public async Task<OrderResponse> Handle(CheckoutOrderCommand request, CancellationToken cancellationToken)
        {
            var order = OrderMapper.Mapper.Map<Order>(request);
            if (order == null)
                throw new ApplicationException("not mapped");
            var neworder = await _order.AddAsync(order);
            var model = OrderMapper.Mapper.Map<OrderResponse>(neworder);
            var eventMessage = OrderMapper.Mapper.Map<OrderCheckoutEvent>(model);

            try
            {
                _eventBus.PublishOrderCheckout(EventBusConstants.OrderCheckoutQueue, eventMessage);
            }
            catch (Exception)
            {

                throw;
            }
            return model;
        }
    }
}
