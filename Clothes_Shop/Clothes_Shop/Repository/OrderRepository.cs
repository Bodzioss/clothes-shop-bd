using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clothes_Shop.Models;

namespace Clothes_Shop.Repository
{
    public class OrderRepository
    {
        private readonly BD2SklepContext _context = null;
        public OrderRepository(BD2SklepContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBook(Orders model)
        {
            var newOrder = new Orders()
            {
                UserId = model.UserId,
                PaymentType = model.PaymentType,
                PaymentStatus = model.PaymentStatus,
                PaymentDate = model.PaymentDate,
                OrderDate = DateTime.UtcNow,
                ShipDate = model.ShipDate,
                ShipperId = model.ShipperId,
                Discount = model.Discount,
                Description = model.Description,
            };

            await _context.Orders.AddAsync(newOrder);
            await _context.SaveChangesAsync();

            return newOrder.OrderId;
        }

       
    }
}
