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
    public class StreetTabsController : Controller
    {
        private readonly BD2SklepContext _context;

        public StreetTabsController(BD2SklepContext context)
        {
            _context = context;
        }

        // GET: StreetTabs
        public async Task<IActionResult> Index()
        {
            return View(await _context.StreetTab.ToListAsync());
        }

        // GET: StreetTabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var streetTab = await _context.StreetTab
                .FirstOrDefaultAsync(m => m.StreetId == id);
            if (streetTab == null)
            {
                return NotFound();
            }

            return View(streetTab);
        }

        // GET: StreetTabs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StreetTabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StreetId,StreetName")] StreetTab streetTab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(streetTab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(streetTab);
        }

        // GET: StreetTabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var streetTab = await _context.StreetTab.FindAsync(id);
            if (streetTab == null)
            {
                return NotFound();
            }
            return View(streetTab);
        }

        // POST: StreetTabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("StreetId,StreetName")] StreetTab streetTab)
        {
            if (id != streetTab.StreetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(streetTab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StreetTabExists(streetTab.StreetId))
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
            return View(streetTab);
        }

        // GET: StreetTabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var streetTab = await _context.StreetTab
                .FirstOrDefaultAsync(m => m.StreetId == id);
            if (streetTab == null)
            {
                return NotFound();
            }

            return View(streetTab);
        }

        // POST: StreetTabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var streetTab = await _context.StreetTab.FindAsync(id);
            _context.StreetTab.Remove(streetTab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StreetTabExists(int id)
        {
            return _context.StreetTab.Any(e => e.StreetId == id);
        }
    }
}
