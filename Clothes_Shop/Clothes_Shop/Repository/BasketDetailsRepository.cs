using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clothes_Shop.Models;

namespace Clothes_Shop.Repository
{
    public class BasketDetailsRepository
    {
        private readonly BD2SklepContext _context = null;
        public BasketDetailsRepository(BD2SklepContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBasketDetails(BasketDetails model)
        {
            var newBasket = new BasketDetails()
            {
                BasketId = model.BasketId,
                ProductId = model.ProductId,
                Quantity = model.Quantity
            };

            await _context.BasketDetails.AddAsync(newBasket);
            await _context.SaveChangesAsync();

            return newBasket.BasketId;
        }
    }
}
