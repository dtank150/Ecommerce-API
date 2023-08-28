using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class CustomerBasket : BaseEntity
    {
        public CustomerBasket()
        {
        }

        public CustomerBasket(int basketId)
        {
        }
        public int ProductId { get; set; }
        public ICollection<BasketItem> Items { get; set; }
        //public List<Product> Products { get; set; }
    }
}
