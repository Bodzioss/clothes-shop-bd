using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clothes_Shop.Models;

namespace Clothes_Shop.Controllers
{
    public class OpinionsController : Controller
    {
        private readonly BD2SklepContext _context;

        public OpinionsController(BD2SklepContext context)
        {
            _context = context;
        }

        // GET: Opinions
        public async Task<IActionResult> Index()
        {
            var bD2SklepContext = _context.Opinion.Include(o => o.Product).Include(o => o.User);
            return View(await bD2SklepContext.ToListAsync());
        }

        // GET: Opinions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opinion = await _context.Opinion
                .Include(o => o.Product)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OpinionId == id);
            if (opinion == null)
            {
                return NotFound();
            }

            return View(opinion);
        }

        // GET: Opinions/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Pattern");
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email");
            return View();
        }

        // POST: Opinions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OpinionId,ProductId,UserId,Text,Date,Rate")] Opinion opinion)
        {
            if (ModelState.IsValid)
            {
                _context.Add(opinion);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Pattern", opinion.ProductId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email", opinion.UserId);
            return View(opinion);
        }

        // GET: Opinions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opinion = await _context.Opinion.FindAsync(id);
            if (opinion == null)
            {
                return NotFound();
            }
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Pattern", opinion.ProductId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email", opinion.UserId);
            return View(opinion);
        }

        // POST: Opinions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("OpinionId,ProductId,UserId,Text,Date,Rate")] Opinion opinion)
        {
            if (id != opinion.OpinionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(opinion);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OpinionExists(opinion.OpinionId))
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
            ViewData["ProductId"] = new SelectList(_context.Product, "ProductId", "Pattern", opinion.ProductId);
            ViewData["UserId"] = new SelectList(_context.User, "UserId", "Email", opinion.UserId);
            return View(opinion);
        }

        // GET: Opinions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var opinion = await _context.Opinion
                .Include(o => o.Product)
                .Include(o => o.User)
                .FirstOrDefaultAsync(m => m.OpinionId == id);
            if (opinion == null)
            {
                return NotFound();
            }

            return View(opinion);
        }

        // POST: Opinions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var opinion = await _context.Opinion.FindAsync(id);
            _context.Opinion.Remove(opinion);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OpinionExists(int id)
        {
            return _context.Opinion.Any(e => e.OpinionId == id);
        }
    }
}
