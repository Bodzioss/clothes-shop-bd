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
    public class CityTabsController : Controller
    {
        private readonly BD2SklepContext _context;

        public CityTabsController(BD2SklepContext context)
        {
            _context = context;
        }

        public IEnumerable<CityTab> displayCityTabs;

        // GET: CityTabs
        public async Task<IActionResult> Index()
        {
            displayCityTabs = await _context.CityTab.ToListAsync();
            return View(await _context.CityTab.ToListAsync());
        }

        // GET: CityTabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityTab = await _context.CityTab
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (cityTab == null)
            {
                return NotFound();
            }

            return View(cityTab);
        }

        // GET: CityTabs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CityTabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CityId,CityName")] CityTab cityTab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cityTab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cityTab);
        }

        // GET: CityTabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityTab = await _context.CityTab.FindAsync(id);
            if (cityTab == null)
            {
                return NotFound();
            }
            return View(cityTab);
        }

        // POST: CityTabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CityId,CityName")] CityTab cityTab)
        {
            if (id != cityTab.CityId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cityTab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CityTabExists(cityTab.CityId))
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
            return View(cityTab);
        }

        // GET: CityTabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cityTab = await _context.CityTab
                .FirstOrDefaultAsync(m => m.CityId == id);
            if (cityTab == null)
            {
                return NotFound();
            }

            return View(cityTab);
        }

        // POST: CityTabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cityTab = await _context.CityTab.FindAsync(id);
            _context.CityTab.Remove(cityTab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CityTabExists(int id)
        {
            return _context.CityTab.Any(e => e.CityId == id);
        }
    }
}
