using System;
using System.Collections.Generic;
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
    public class OrderDetailsController : Controller
    {
        private readonly BD2SklepContext _context;
        private readonly OrderRepository _orderRepository;
        private readonly OrderDetailsRepository _orderDetailsRepository;

        public OrderDetailsController(BD2SklepContext context, OrderDetailsRepository orderDetailsRepository, OrderRepository orderRepository)
        {
            _context = context;
            _orderDetailsRepository = orderDetailsRepository;
            _orderRepository = orderRepository;
        }

        // GET: OrderDetails
        public async Task<IActionResult> Index()
        {
            var bD2SklepContext = _context.OrderDetails.Include(o => o.Order).Include(o => o.Product);
            return View(await bD2SklepContext.ToListAsync());
        }

        // GET: OrderDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderDetailsId == id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(orderDetails);
        }

        // GET: OrderDetails/Create
        public IActionResult Create()
        {
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "PaymentStatus");
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Pattern");
            return View();
        }

        // POST: OrderDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrderDetailsId,OrderId,ProductId,Quantity,Discount")] OrderDetails orderDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(orderDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "PaymentStatus", orderDetails.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Pattern", orderDetails.ProductId);
            return View(orderDetails);
        }

        // GET: OrderDetails/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails.FindAsync(id);
            if (orderDetails == null)
            {
                return NotFound();
            }
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "PaymentStatus", orderDetails.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Pattern", orderDetails.ProductId);
            return View(orderDetails);
        }

        // POST: OrderDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OrderDetailsId,OrderId,ProductId,Quantity,Discount")] OrderDetails orderDetails)
        {
            if (id != orderDetails.OrderDetailsId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(orderDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderDetailsExists(orderDetails.OrderDetailsId))
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
            ViewData["OrderId"] = new SelectList(_context.Orders, "OrderId", "PaymentStatus", orderDetails.OrderId);
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Pattern", orderDetails.ProductId);
            return View(orderDetails);
        }

        // GET: OrderDetails/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var orderDetails = await _context.OrderDetails
                .Include(o => o.Order)
                .Include(o => o.Product)
                .FirstOrDefaultAsync(m => m.OrderDetailsId == id);
            if (orderDetails == null)
            {
                return NotFound();
            }

            return View(orderDetails);
        }

        // POST: OrderDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var orderDetails = await _context.OrderDetails.FindAsync(id);
            _context.OrderDetails.Remove(orderDetails);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderDetailsExists(int id)
        {
            return _context.OrderDetails.Any(e => e.OrderDetailsId == id);
        }

        public IActionResult FinalizeOrderDetails(int? id)
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Pattern", id);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FinalizeOrderDetails(OrderDetails orderDetails, int id)
        {
            Orders orders;
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            orders = new Orders();
            orders.UserId = userId;
            orders.PaymentType = orders.OrderId.ToString();
            orders.PaymentStatus = "Rozpoczęta";
            orders.ShipperId = 1;
            await _orderRepository.AddNewOrder(orders);
            orders = await _context.Orders.FirstOrDefaultAsync(m => m.UserId == userId);
            orderDetails.OrderId = orders.OrderId;
            orderDetails.ProductId = id;
            await _orderDetailsRepository.AddNewOrderDetails(orderDetails);

            return RedirectToAction("FinalizeOrder", "Orders", new { id = orders.OrderId });
        }
    }
}
