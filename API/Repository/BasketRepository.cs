using API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using API.Data;

namespace API.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly StoreContext _dbContext;

        public BasketRepository(StoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteBasketAsync(int basketId)
        {
            var basket = await GetBasketAsync(basketId);
            if (basket == null)
                return false;

            _dbContext.Remove(basket);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<CustomerBasket> GetBasketAsync(int basketId)
        {
            return await _dbContext.Set<CustomerBasket>().FindAsync(basketId);
        }

        public Task<CustomerBasket> GetBasketAsync(string basketID)
        {
            throw new NotImplementedException();
        }

        public Task GetBasketAsync(object basketId)
        {
            throw new NotImplementedException();
        }

        public async Task<CustomerBasket> UpdateBasketAsync(CustomerBasket basket)
        {
            var existingBasket = await GetBasketAsync(basket.Id);
            if (existingBasket == null)
            {
                _dbContext.Set<CustomerBasket>().Add(basket);
            }
            else
            {
                existingBasket.ProductId = basket.ProductId; // Update the basket items
                _dbContext.Set<CustomerBasket>().Update(existingBasket);
            }

            await _dbContext.SaveChangesAsync();
            return await GetBasketAsync(basket.Id);
        }

       
    }
}



