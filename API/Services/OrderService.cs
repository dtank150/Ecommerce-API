using API.Entities;
using API.Entities.OrderAggregate;
using API.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Services
{
    public class OrderService : IOrderService
    {
        private readonly IGenericRepository<Orders> _orderRepo;
        private readonly IGenericRepository<DeliveryMethod> _dmRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IBasketRepository _basketRepo;
        private int basketId;

        public OrderService(IGenericRepository<Orders> orderRepo, IGenericRepository<DeliveryMethod> dmRepo, 
            IGenericRepository<Product> productRepo, IBasketRepository basketRepo)
        {
            _orderRepo = orderRepo;
            _dmRepo = dmRepo;
            _productRepo = productRepo;
            _basketRepo = basketRepo;
        }

        public int Quantity { get; private set; }
        public int id { get; private set; }

        public async Task<Orders> CreateOrderAsync(string buyerEmail, int deliveryMethod, string basketID, Address shippingAddress)
        {
            //get basket from the repo
            //var basket = await _basketRepo.GetBasketAsync(basketId);
            //get items from the product repo
            var items = new List<OrderItem>();
/*            foreach(var item in basket.Items)
            {
                var productItem = await _productRepo.GetByIdAsync(id);
                var itemOredered = new ProductItemOrdered(productItem.Id, productItem.Name, productItem.PictureUrl);
                var orderItem = new OrderItem(itemOredered, productItem.Price, Quantity);
                items.Add(orderItem);
            }*/
            //get delivery method from repo
            //calc subtotal
            var subtotal = items.Sum(item => item.Price * item.Quantity);
            //create Order
            var order = new Orders(items, buyerEmail, shippingAddress, await _dmRepo.GetByIdAsync(deliveryMethod), subtotal);
            //save to db
            //return Order
            return order;
        }

        public Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Orders> GetOrderByIdAsync(int id, string buyerEmail)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Orders>> GetOrdersForUserAsync(string buyerEmail)
        {
            throw new NotImplementedException();
        }
    }
}
