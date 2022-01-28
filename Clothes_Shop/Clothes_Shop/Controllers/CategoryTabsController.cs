using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clothes_Shop.Models;

namespace Clothes_Shop.Controllers
{
    public class CategoryTabsController : Controller
    {
        private readonly BD2SklepContext _context;

        public CategoryTabsController(BD2SklepContext context)
        {
            _context = context;
        }

        // GET: CategoryTabs
        public async Task<IActionResult> Index()
        {
            return View(await _context.CategoryTab.ToListAsync());
        }

        // GET: CategoryTabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryTab = await _context.CategoryTab
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (categoryTab == null)
            {
                return NotFound();
            }

            return View(categoryTab);
        }

        // GET: CategoryTabs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryTabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CategoryId,CategoryName,Description,Picture")] CategoryTab categoryTab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(categoryTab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(categoryTab);
        }

        // GET: CategoryTabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryTab = await _context.CategoryTab.FindAsync(id);
            if (categoryTab == null)
            {
                return NotFound();
            }
            return View(categoryTab);
        }

        // POST: CategoryTabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CategoryId,CategoryName,Description,Picture")] CategoryTab categoryTab)
        {
            if (id != categoryTab.CategoryId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryTab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryTabExists(categoryTab.CategoryId))
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
            return View(categoryTab);
        }

        // GET: CategoryTabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categoryTab = await _context.CategoryTab
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (categoryTab == null)
            {
                return NotFound();
            }

            return View(categoryTab);
        }

        // POST: CategoryTabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var categoryTab = await _context.CategoryTab.FindAsync(id);
            _context.CategoryTab.Remove(categoryTab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryTabExists(int id)
        {
            return _context.CategoryTab.Any(e => e.CategoryId == id);
        }
    }
}
