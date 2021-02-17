using Basket.Api.Data.Interfaces;
using Basket.Api.Entities;
using Basket.Api.Repository.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Api.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IBasketContext _context;

        public BasketRepository(IBasketContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteBasket(string username)
        {
            return await _context.Redis.KeyDeleteAsync(username);
        }

        public async Task<BasketCart> GetBasket(string username)
        {
            var basket = await _context.Redis.StringGetAsync(username);
            if (basket.IsNullOrEmpty)
                return null;

            return JsonConvert.DeserializeObject<BasketCart>(basket);
        }

        public async Task<BasketCart> UpdateBasket(BasketCart basket)
        {
            bool updated = await _context.Redis.StringSetAsync(basket.UserName, JsonConvert.SerializeObject(basket));
            if (!updated)
                return null;
            return await GetBasket(basket.UserName);
        }
    }
}
