using API.Data;
using API.Entities;
using API.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class BasketController : BaseApiController
    {
        private readonly IBasketRepository _basketRepository;

        public BasketController(IBasketRepository basketRepository)
        {
            _basketRepository = basketRepository;
        }

        //[HttpGet]
        //public async Task<ActionResult<CustomerBasket>> GetBasketById(int basketId)
        //{
        //    var basket = await _basketRepository.GetBasketAsync(basketId);

        //    return Ok(basket ?? new CustomerBasket(basketId));
        //}

        [HttpGet]
        public async Task<ActionResult<CustomerBasket>> GetBasketById(int basketId)
        {
            var basket = await _basketRepository.GetBasketAsync(basketId);
            if (basket == null)
            {
                basket = new CustomerBasket(basketId);
            }

            return Ok(basket);
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<CustomerBasket>>> UpdateBaskets(IEnumerable<CustomerBasket> baskets)
        {
            var updatedBaskets = new List<CustomerBasket>();

            foreach (var basket in baskets)
            {
                var updatedBasket = await _basketRepository.UpdateBasketAsync(basket);
                updatedBaskets.Add(updatedBasket);
            }

            return Ok(updatedBaskets);
        }


        [HttpDelete]
        public async Task DeleteBasketAsync(int id)
        {
            await _basketRepository.DeleteBasketAsync(id);
        }
    }
}
