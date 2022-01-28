using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clothes_Shop.Models;

namespace Clothes_Shop.Controllers
{
    public class SizeTabsController : Controller
    {
        private readonly BD2SklepContext _context;

        public SizeTabsController(BD2SklepContext context)
        {
            _context = context;
        }

        // GET: SizeTabs
        public async Task<IActionResult> Index()
        {
            return View(await _context.SizeTab.ToListAsync());
        }

        // GET: SizeTabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sizeTab = await _context.SizeTab
                .FirstOrDefaultAsync(m => m.SizeId == id);
            if (sizeTab == null)
            {
                return NotFound();
            }

            return View(sizeTab);
        }

        // GET: SizeTabs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SizeTabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SizeId,SizeName")] SizeTab sizeTab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sizeTab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sizeTab);
        }

        // GET: SizeTabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sizeTab = await _context.SizeTab.FindAsync(id);
            if (sizeTab == null)
            {
                return NotFound();
            }
            return View(sizeTab);
        }

        // POST: SizeTabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SizeId,SizeName")] SizeTab sizeTab)
        {
            if (id != sizeTab.SizeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sizeTab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SizeTabExists(sizeTab.SizeId))
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
            return View(sizeTab);
        }

        // GET: SizeTabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sizeTab = await _context.SizeTab
                .FirstOrDefaultAsync(m => m.SizeId == id);
            if (sizeTab == null)
            {
                return NotFound();
            }

            return View(sizeTab);
        }

        // POST: SizeTabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sizeTab = await _context.SizeTab.FindAsync(id);
            _context.SizeTab.Remove(sizeTab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SizeTabExists(int id)
        {
            return _context.SizeTab.Any(e => e.SizeId == id);
        }
    }
}
