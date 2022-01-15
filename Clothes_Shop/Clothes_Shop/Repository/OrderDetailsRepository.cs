using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clothes_Shop.Models;

namespace Clothes_Shop.Repository
{
    public class OrderDetailsRepository
    {
        private readonly BD2SklepContext _context = null;
        public OrderDetailsRepository(BD2SklepContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewOrderDetails(OrderDetails model)
        {
            var newOrderDetails = new OrderDetails()
            {
                OrderId = model.OrderId,
                ProductId = model.ProductId,
                Quantity = model.Quantity
            };

            await _context.OrderDetails.AddAsync(newOrderDetails);
            await _context.SaveChangesAsync();

            return newOrderDetails.OrderId;
        }
    }
}
