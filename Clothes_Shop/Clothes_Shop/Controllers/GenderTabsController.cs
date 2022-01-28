using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Clothes_Shop.Models;

namespace Clothes_Shop.Controllers
{
    public class GenderTabsController : Controller
    {
        private readonly BD2SklepContext _context;

        public GenderTabsController(BD2SklepContext context)
        {
            _context = context;
        }

        // GET: GenderTabs
        public async Task<IActionResult> Index()
        {
            return View(await _context.GenderTab.ToListAsync());
        }

        // GET: GenderTabs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genderTab = await _context.GenderTab
                .FirstOrDefaultAsync(m => m.GenderId == id);
            if (genderTab == null)
            {
                return NotFound();
            }

            return View(genderTab);
        }

        // GET: GenderTabs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GenderTabs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GenderId,GenderName")] GenderTab genderTab)
        {
            if (ModelState.IsValid)
            {
                _context.Add(genderTab);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(genderTab);
        }

        // GET: GenderTabs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genderTab = await _context.GenderTab.FindAsync(id);
            if (genderTab == null)
            {
                return NotFound();
            }
            return View(genderTab);
        }

        // POST: GenderTabs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GenderId,GenderName")] GenderTab genderTab)
        {
            if (id != genderTab.GenderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(genderTab);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GenderTabExists(genderTab.GenderId))
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
            return View(genderTab);
        }

        // GET: GenderTabs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var genderTab = await _context.GenderTab
                .FirstOrDefaultAsync(m => m.GenderId == id);
            if (genderTab == null)
            {
                return NotFound();
            }

            return View(genderTab);
        }

        // POST: GenderTabs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var genderTab = await _context.GenderTab.FindAsync(id);
            _context.GenderTab.Remove(genderTab);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GenderTabExists(int id)
        {
            return _context.GenderTab.Any(e => e.GenderId == id);
        }
    }
}
