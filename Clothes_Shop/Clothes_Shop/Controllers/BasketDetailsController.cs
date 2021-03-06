using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clothes_Shop.Models;
using Clothes_Shop.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Clothes_Shop.Controllers
{
    public class BasketDetailsController : Controller
    {
        private readonly BD2SklepContext _context;
        private readonly BasketRepository _basketRepository;
        private readonly BasketDetailsRepository _basketDetailsRepository;

        public BasketDetailsController(BD2SklepContext context, BasketRepository basketRepository, BasketDetailsRepository basketDetailsRepository)
        {
            _context = context;
            _basketRepository = basketRepository;
            _basketDetailsRepository = basketDetailsRepository;
        }

        // GET: BasketDetails
        public async Task<IActionResult> Index(String? id)
        {
            if (id == null)
            {
                var bD2SklepContext = _context.BasketDetails.Include(b => b.Basket).Include(b => b.Product);
                return View(await bD2SklepContext.ToListAsync());
            }
            else
            {
                var basket = _context.Basket.Include(b => b.User).FirstOrDefaultAsync(m => m.UserId == id);
                if (basket==null)
                {
                    var basketId = _context.Basket.Include(b => b.User).FirstOrDefault(m => m.UserId == id).BasketId;

                    var bD2SklepContext = _context.BasketDetails.Include(b => b.Basket).Include(b => b.Product)
                        .Where(m => m.BasketId == basketId).ToArray();
                    return View(bD2SklepContext);
                }
                else
                {
                    return View();
                }
            }

            
        }

      

        // GET: BasketDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basketDetails = await _context.BasketDetails
                .Include(b => b.Basket)
                .Include(b => b.Product)
                .FirstOrDefaultAsync(m => m.BasketDetailsId == id);
            if (basketDetails == null)
            {
                return NotFound();
            }

            return View(basketDetails);
        }

        // GET: BasketDetails/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["BasketId"] = new SelectList(_context.Basket, "BasketId", "UserId");
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Pattern");
            return View();
        }

        // POST: BasketDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BasketDetailsId,BasketId,ProductId,Quantity")] BasketDetails basketDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(basketDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BasketId"] = new SelectList(_context.Basket, "BasketId", "UserId", basketDetails.BasketId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Pattern", basketDetails.ProductId);
            return View(basketDetails);
        }

        // GET: BasketDetails/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basketDetails = await _context.BasketDetails.FindAsync(id);
            if (basketDetails == null)
            {
                return NotFound();
            }
            ViewData["BasketId"] = new SelectList(_context.Basket, "BasketId", "UserId", basketDetails.BasketId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Pattern", basketDetails.ProductId);
            return View(basketDetails);
        }

        // POST: BasketDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BasketDetailsId,BasketId,ProductId,Quantity")] BasketDetails basketDetails)
        {
            if (id != basketDetails.BasketDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(basketDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasketDetailsExists(basketDetails.BasketDetailsId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["BasketId"] = new SelectList(_context.Basket, "BasketId", "UserId", basketDetails.BasketId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Pattern", basketDetails.ProductId);
            return View(basketDetails);
        }

        // GET: BasketDetails/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basketDetails = await _context.BasketDetails
                .Include(b => b.Basket)
                .Include(b => b.Product)
                .FirstOrDefaultAsync(m => m.BasketDetailsId == id);
            if (basketDetails == null)
            {
                return NotFound();
            }

            return View(basketDetails);
        }

        // POST: BasketDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var basketDetails = await _context.BasketDetails.FindAsync(id);
            _context.BasketDetails.Remove(basketDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasketDetailsExists(int id)
        {
            return _context.BasketDetails.Any(e => e.BasketDetailsId == id);
        }


        public IActionResult AddToBasket(int? id)
        {

            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Pattern", id);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddToBasket(BasketDetails basketDetails, int id)
        {
            Basket basket;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!(_context.Basket.Any(e => e.UserId == userId)))
            {
                basket = new Basket();
                basket.UserId = userId;
                await _basketRepository.AddNewBasket(basket);
            }

            basket = await _context.Basket.FirstOrDefaultAsync(m => m.UserId == userId);
            basketDetails.BasketId = basket.BasketId;
            basketDetails.ProductId = id;
            await _basketDetailsRepository.AddNewBasketDetails(basketDetails);

            return RedirectToAction("Index");
        }
    }
}