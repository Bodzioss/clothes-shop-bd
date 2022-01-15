using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clothes_Shop.Models;

namespace Clothes_Shop.Repository
{
    public class BasketRepository
    {
        private readonly BD2SklepContext _context = null;
        public BasketRepository(BD2SklepContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewBasket(Basket model)
        {
            var newBasket = new Basket()
            {
                UserId = model.UserId,
            };

            await _context.Basket.AddAsync(newBasket);
            await _context.SaveChangesAsync();

            return newBasket.BasketId;
        }


    }
}

