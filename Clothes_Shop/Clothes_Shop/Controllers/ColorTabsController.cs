using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clothes_Shop.Models;

namespace Clothes_Shop.Controllers
{
    public class ColorTabsController : Controller
    {
        private readonly BD2SklepContext _context;

        public ColorTabsController(BD2SklepContext context)
        {
            _context = context;
        }

        // GET: ColorTabs
        public async Task<IActionResult> Index()
        {
            return View(await _context.ColorTab.ToListAsync());
        }

        // GET: ColorTabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colorTab = await _context.ColorTab
                .FirstOrDefaultAsync(m => m.ColorId == id);
            if (colorTab == null)
            {
                return NotFound();
            }

            return View(colorTab);
        }

        // GET: ColorTabs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ColorTabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ColorId,ColorName")] ColorTab colorTab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(colorTab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(colorTab);
        }

        // GET: ColorTabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colorTab = await _context.ColorTab.FindAsync(id);
            if (colorTab == null)
            {
                return NotFound();
            }
            return View(colorTab);
        }

        // POST: ColorTabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ColorId,ColorName")] ColorTab colorTab)
        {
            if (id != colorTab.ColorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(colorTab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ColorTabExists(colorTab.ColorId))
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
            return View(colorTab);
        }

        // GET: ColorTabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var colorTab = await _context.ColorTab
                .FirstOrDefaultAsync(m => m.ColorId == id);
            if (colorTab == null)
            {
                return NotFound();
            }

            return View(colorTab);
        }

        // POST: ColorTabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var colorTab = await _context.ColorTab.FindAsync(id);
            _context.ColorTab.Remove(colorTab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ColorTabExists(int id)
        {
            return _context.ColorTab.Any(e => e.ColorId == id);
        }
    }
}
