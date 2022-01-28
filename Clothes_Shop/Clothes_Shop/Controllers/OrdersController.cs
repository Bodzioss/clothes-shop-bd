using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Clothes_Shop.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clothes_Shop.Models;
using Clothes_Shop.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Clothes_Shop.Controllers
{
    public class OrdersController : Controller
    {
        private readonly BD2SklepContext _context;
        private readonly OrderRepository _orderRepository = null;
        private readonly OrderDetailsRepository _orderDetailsRepository = null;
        private readonly UserManager<ApplicationUser> _userManager;

        public OrdersController(BD2SklepContext context, OrderRepository orderRepository, UserManager<ApplicationUser> userManager, OrderDetailsRepository orderDetailsRepository)
        {
            _context = context;
            _orderRepository = orderRepository;
            _orderDetailsRepository = orderDetailsRepository;
            _userManager = userManager;
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
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["ShipperId"] = new SelectList(_context.Shipper, "ShipperId", "CompanyName");
            ViewData["UserId"] = new SelectList(_context.AspNetUsers, "Id", "Id");
            return View();
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
        [Authorize(Roles = "Admin")]
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
        [Authorize(Roles = "Admin")]
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


        public async Task<IActionResult> FinalizeOrder(int? id)
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
            return View(orders);
        }

        [HttpPost]
        public async Task<IActionResult> FinalizeOrder(int id, [Bind("OrderId,UserId,PaymentType,PaymentStatus,PaymentDate,OrderDate,ShipDate,ShipperId,Discount,Description")] Orders orders)
        {
            orders.OrderDate = DateTime.UtcNow;
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

        public async Task<IActionResult> CreateFromBasketAsync(int id)
        {
            var basketDetailsArray = _context.BasketDetails.Where(m => m.BasketId == id).ToArray();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var orders = new Orders();
            orders.OrderId = _context.Orders.Where(m => m.UserId == userId).ToArray().LastOrDefault().OrderId;
            orders.OrderId = orders.OrderId + 1;
            orders.UserId = userId;
            orders.PaymentType = orders.OrderId.ToString();
            orders.PaymentStatus = "Rozpoczęta";
            orders.ShipperId = 1;
            var orderID =  await  _orderRepository.AddNewOrder(orders);
            foreach (var basketDetails in basketDetailsArray)
            {
                var orderDetails = new OrderDetails();
                orderDetails.OrderId = orderID;
                orderDetails.ProductId = basketDetails.ProductId;
                orderDetails.Quantity = basketDetails.Quantity;
                orderDetails.Discount = 0;
                await _orderDetailsRepository.AddNewOrderDetails(orderDetails);
            }

            return RedirectToAction("FinalizeOrder", "Orders", new { id = orderID });
        }
    }
}