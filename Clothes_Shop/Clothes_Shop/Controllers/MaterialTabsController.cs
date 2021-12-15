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
    public class MaterialTabsController : Controller
    {
        private readonly BD2SklepContext _context;

        public MaterialTabsController(BD2SklepContext context)
        {
            _context = context;
        }

        // GET: MaterialTabs
        public async Task<IActionResult> Index()
        {
            return View(await _context.MaterialTab.ToListAsync());
        }

        // GET: MaterialTabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialTab = await _context.MaterialTab
                .FirstOrDefaultAsync(m => m.MaterialId == id);
            if (materialTab == null)
            {
                return NotFound();
            }

            return View(materialTab);
        }

        // GET: MaterialTabs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MaterialTabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaterialId,MaterialName")] MaterialTab materialTab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(materialTab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(materialTab);
        }

        // GET: MaterialTabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialTab = await _context.MaterialTab.FindAsync(id);
            if (materialTab == null)
            {
                return NotFound();
            }
            return View(materialTab);
        }

        // POST: MaterialTabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaterialId,MaterialName")] MaterialTab materialTab)
        {
            if (id != materialTab.MaterialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(materialTab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MaterialTabExists(materialTab.MaterialId))
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
            return View(materialTab);
        }

        // GET: MaterialTabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var materialTab = await _context.MaterialTab
                .FirstOrDefaultAsync(m => m.MaterialId == id);
            if (materialTab == null)
            {
                return NotFound();
            }

            return View(materialTab);
        }

        // POST: MaterialTabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var materialTab = await _context.MaterialTab.FindAsync(id);
            _context.MaterialTab.Remove(materialTab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MaterialTabExists(int id)
        {
            return _context.MaterialTab.Any(e => e.MaterialId == id);
        }
    }
}
