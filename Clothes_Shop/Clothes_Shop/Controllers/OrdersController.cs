using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clothes_Shop.Models;
using Clothes_Shop.Repository;
using Microsoft.AspNetCore.Authorization;

namespace Clothes_Shop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly BD2SklepContext _context;
        private readonly OrderRepository _orderRepository = null;

        public OrdersController(BD2SklepContext context, OrderRepository orderRepository)
        {
            _context = context;
            _orderRepository = orderRepository;
        }
      

        // GET: Orders
        public async Task<IActionResult> Index()
        {
            var bD2SklepContext = _context.Orders.Include(o => o.Shipper).Include(o => o.User);
            return View(await bD2SklepContext.ToListAsync());
        }

        // GET: Orders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.Shipper)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // GET: Orders/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["ShipperId"] = new SelectList(_context.Shipper, "ShipperId", "CompanyName");
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(String paymentType,int shipperId,int discount,string description)
        {
            Orders model = new Orders();
            model.UserId = "0";
            model.PaymentType = paymentType;
            model.PaymentStatus = "Rozpoczęta";
            model.PaymentDate = null;
            model.OrderDate = DateTime.UtcNow;
            model.ShipDate = null;
            model.ShipperId = shipperId;
            model.Discount = discount;
            model.Description = description;
            int id = await _orderRepository.AddNewBook(model);

            return RedirectToAction("Index");
        }


        // POST: Orders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderId,UserId,PaymentType,PaymentStatus,PaymentDate,OrderDate,ShipDate,ShipperId,Discount,Description")] Orders orders)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orders);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ShipperId"] = new SelectList(_context.Shipper, "ShipperId", "CompanyName", orders.ShipperId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", orders.UserId);
            return View(orders);
        }

        // GET: Orders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders.FindAsync(id);
            if (orders == null)
            {
                return NotFound();
            }
            ViewData["ShipperId"] = new SelectList(_context.Shipper, "ShipperId", "CompanyName", orders.ShipperId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", orders.UserId);
            return View(orders);
        }

        // POST: Orders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderId,UserId,PaymentType,PaymentStatus,PaymentDate,OrderDate,ShipDate,ShipperId,Discount,Description")] Orders orders)
        {
            if (id != orders.OrderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orders);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrdersExists(orders.OrderId))
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
            ViewData["ShipperId"] = new SelectList(_context.Shipper, "ShipperId", "CompanyName", orders.ShipperId);
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id", orders.UserId);
            return View(orders);
        }

        // GET: Orders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orders = await _context.Orders
                .Include(o => o.Shipper)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            if (orders == null)
            {
                return NotFound();
            }

            return View(orders);
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orders = await _context.Orders.FindAsync(id);
            _context.Orders.Remove(orders);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrdersExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }

 
        public IActionResult FinalizeOrder()
        {
          
            return View();
        }
    }
}
