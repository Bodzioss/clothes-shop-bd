using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clothes_Shop.Models;

namespace Clothes_Shop.Controllers
{
    public class BrandTabsController : Controller
    {
        private readonly BD2SklepContext _context;

        public BrandTabsController(BD2SklepContext context)
        {
            _context = context;
        }

        // GET: BrandTabs
        public async Task<IActionResult> Index()
        {
            return View(await _context.BrandTab.ToListAsync());
        }

        // GET: BrandTabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brandTab = await _context.BrandTab
                .FirstOrDefaultAsync(m => m.BrandId == id);
            if (brandTab == null)
            {
                return NotFound();
            }

            return View(brandTab);
        }

        // GET: BrandTabs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BrandTabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BrandId,BrandName")] BrandTab brandTab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(brandTab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(brandTab);
        }

        // GET: BrandTabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brandTab = await _context.BrandTab.FindAsync(id);
            if (brandTab == null)
            {
                return NotFound();
            }
            return View(brandTab);
        }

        // POST: BrandTabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BrandId,BrandName")] BrandTab brandTab)
        {
            if (id != brandTab.BrandId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(brandTab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BrandTabExists(brandTab.BrandId))
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
            return View(brandTab);
        }

        // GET: BrandTabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var brandTab = await _context.BrandTab
                .FirstOrDefaultAsync(m => m.BrandId == id);
            if (brandTab == null)
            {
                return NotFound();
            }

            return View(brandTab);
        }

        // POST: BrandTabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var brandTab = await _context.BrandTab.FindAsync(id);
            _context.BrandTab.Remove(brandTab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BrandTabExists(int id)
        {
            return _context.BrandTab.Any(e => e.BrandId == id);
        }
    }
}
