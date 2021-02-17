using AutoMapper;
using EventBusRabbitMq.Common;
using EventBusRabbitMq.Events;
using EventBusRabbitMq.Producer;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Commands;
using Ordering.Application.Queries;
using Ordering.Application.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Ordering.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderController : Controller
    {
        private readonly IMediator _mediator;

        public OrderController(IMediator mediator, EventBusRabbitMQProducer eventBus, IMapper mapper)
        {
            _mediator = mediator;
        }

        [HttpGet("{username}")]
        [ProducesResponseType(typeof(IEnumerable<OrderResponse>), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<IEnumerable<OrderResponse>>> Get(string username)
        {
            var query = new GetOrderByUsernameQuery(username);
            var model = await _mediator.Send(query);
            return Ok(model);
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType(typeof(OrderResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<OrderResponse>> Checkout(CheckoutOrderCommand checkoutOrderCommand)
        {
            var model = await _mediator.Send(checkoutOrderCommand);
            
            return Ok(model);
        }
    }
}
