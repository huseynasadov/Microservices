using AutoMapper;
using Basket.Api.Entities;
using Basket.Api.Repository.Interfaces;
using EventBusRabbitMq.Common;
using EventBusRabbitMq.Events;
using EventBusRabbitMq.Producer;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Basket.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class BasketController : Controller
    {
        private readonly IBasketRepository _basket;
        private readonly IMapper _mapper;
        private readonly EventBusRabbitMQProducer _eventBus;

        public BasketController(IBasketRepository basket, IMapper mapper, EventBusRabbitMQProducer eventBus)
        {
            _basket = basket;
            _mapper = mapper;
            _eventBus = eventBus;
        }

        [HttpGet("{username}")]
        [ProducesResponseType(typeof(BasketCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketCart>> Get(string username)
        {
            var basket = await _basket.GetBasket(username);
            return basket;
        }

        [HttpPost]
        [ProducesResponseType(typeof(BasketCart), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<BasketCart>> Update(BasketCart basket)
        {
            var result = await _basket.UpdateBasket(basket);
            return result;
        }

        [HttpDelete("{username}")]
        [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(string username)
        {
            return Ok(await _basket.DeleteBasket(username));
        }

        [HttpPost]
        [Route("[action]")]
        [ProducesResponseType((int)HttpStatusCode.Accepted)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Checkout(BasketCheckout basketCheckout)
        {
            var basket = await _basket.GetBasket(basketCheckout.UserName);
            if (basket == null)
                return BadRequest();
            var removebasket = await _basket.DeleteBasket(basketCheckout.UserName);
            if (!removebasket)
                return BadRequest();

            var eventMessage = _mapper.Map<BasketCheckoutEvent>(basketCheckout);

            try
            {
                _eventBus.PublishBasketCheckout(EventBusConstants.BasketCheckoutQueue,eventMessage);
            }
            catch (Exception)
            {

                throw;
            }
            return Accepted();
        }
    }
}
