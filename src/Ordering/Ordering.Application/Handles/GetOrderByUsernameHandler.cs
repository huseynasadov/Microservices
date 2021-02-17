using MediatR;
using Ordering.Application.Mapper;
using Ordering.Application.Queries;
using Ordering.Application.Responses;
using Ordering.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ordering.Application.Handles
{
    public class GetOrderByUsernameHandler : IRequestHandler<GetOrderByUsernameQuery,IEnumerable<OrderResponse>>
    {
        private readonly IOrderRepository _order;

        public GetOrderByUsernameHandler(IOrderRepository order)
        {
            _order = order;
        }

        public async Task<IEnumerable<OrderResponse>> Handle(GetOrderByUsernameQuery request, CancellationToken cancellationToken) 
        {
            var orderlist = await _order.GetOrdersByUserName(request.UserName);
            var model = OrderMapper.Mapper.Map<IEnumerable<OrderResponse>>(orderlist);
            return model;
        }
    }
}
