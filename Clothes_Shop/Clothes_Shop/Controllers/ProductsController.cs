using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Clothes_Shop.Models;
using Microsoft.AspNetCore.Authorization;

namespace Clothes_Shop.Controllers
{
    public class ProductsController : Controller
    {
        private readonly BD2SklepContext _context;

        public ProductsController(BD2SklepContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(int? id,int? gid)
        {

            var bD2SklepContext = _context.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Gender).Include(p => p.Material).Include(p => p.Size).Where(p => p.ProductName.Contains(""));

            if (id == 0)
            {
                bD2SklepContext=bD2SklepContext.Where(p => p.GenderId.Equals(1));
            }
            else if (id == 1)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(2));
            }
            else if (id == 2)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(3));
            }

            if (id == 13)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(1));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(2));
            }
            else if (id == 14)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(1));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(3));
            }
            else if (id == 15)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(1));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(4));
            }
            else if (id == 16)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(1));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(5));
            }
            else if (id == 17)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(1));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(6));
            }
            else if (id == 18)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(1));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(7));
            }
            else if (id == 19)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(1));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(8));
            }
            else if (id == 110)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(1));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(9));
            }
            else if (id == 111)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(1));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(10));
            }
            else if (id == 112)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(1));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(11));
            }
            else if (id == 113)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(1));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(12));
            }
            else if (id == 114)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(1));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(13));
            }
            else if (id == 23)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(2));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(2));
            }
            else if (id == 24)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(2));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(3));
            }
            else if (id == 25)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(2));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(4));
            }
            else if (id == 26)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(2));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(5));
            }
            else if (id == 27)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(2));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(6));
            }
            else if (id == 28)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(2));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(7));
            }
            else if (id == 29)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(2));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(8));
            }
            else if (id == 210)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(2));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(9));
            }
            else if (id == 211)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(2));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(10));
            }
            else if (id == 212)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(2));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(11));
            }
            else if (id == 213)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(2));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(12));
            }
            else if (id == 214)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(2));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(13));
            }
            else if (id == 33)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(3));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(2));
            }
            else if (id == 34)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(3));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(3));
            }
            else if (id == 35)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(3));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(4));
            }
            else if (id == 36)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(3));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(5));
            }
            else if (id == 37)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(3));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(6));
            }
            else if (id == 38)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(3));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(7));
            }
            else if (id == 39)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(3));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(8));
            }
            else if (id == 310)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(3));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(9));
            }
            else if (id == 311)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(3));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(10));
            }
            else if (id == 312)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(3));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(11));
            }
            else if (id == 313)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(3));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(12));
            }
            else if (id == 314)
            {
                bD2SklepContext = bD2SklepContext.Where(p => p.GenderId.Equals(3));
                bD2SklepContext = bD2SklepContext.Where(p => p.CategoryId.Equals(13));
            }
            return View(await bD2SklepContext.ToListAsync());
        }
       

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Color)
                .Include(p => p.Gender)
                .Include(p => p.Material)
                .Include(p => p.Size)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        public async Task<IActionResult> Index2()
        {
            return View(await _context.Product.ToListAsync());
        }

        // GET: Products/Create
        [Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            ViewData["BrandId"] = new SelectList(_context.BrandTab, "BrandId", "BrandName");
            ViewData["CategoryId"] = new SelectList(_context.CategoryTab, "CategoryId", "CategoryName");
            ViewData["ColorId"] = new SelectList(_context.ColorTab, "ColorId", "ColorName");
            ViewData["GenderId"] = new SelectList(_context.GenderTab, "GenderId", "GenderName");
            ViewData["MaterialId"] = new SelectList(_context.MaterialTab, "MaterialId", "MaterialName");
            ViewData["SizeId"] = new SelectList(_context.SizeTab, "SizeId", "SizeName");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ProductId,ProductName,Season,Price,GenderId,ColorId,SizeId,MaterialId,Pattern,BrandId,CategoryId,Amount,Description,Picture")] Product product)
        {
            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BrandId"] = new SelectList(_context.BrandTab, "BrandId", "BrandName", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.CategoryTab, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["ColorId"] = new SelectList(_context.ColorTab, "ColorId", "ColorName", product.ColorId);
            ViewData["GenderId"] = new SelectList(_context.GenderTab, "GenderId", "GenderName", product.GenderId);
            ViewData["MaterialId"] = new SelectList(_context.MaterialTab, "MaterialId", "MaterialName", product.MaterialId);
            ViewData["SizeId"] = new SelectList(_context.SizeTab, "SizeId", "SizeName", product.SizeId);
            return View(product);
        }

        // GET: Products/Edit/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["BrandId"] = new SelectList(_context.BrandTab, "BrandId", "BrandName", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.CategoryTab, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["ColorId"] = new SelectList(_context.ColorTab, "ColorId", "ColorName", product.ColorId);
            ViewData["GenderId"] = new SelectList(_context.GenderTab, "GenderId", "GenderName", product.GenderId);
            ViewData["MaterialId"] = new SelectList(_context.MaterialTab, "MaterialId", "MaterialName", product.MaterialId);
            ViewData["SizeId"] = new SelectList(_context.SizeTab, "SizeId", "SizeName", product.SizeId);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductId,ProductName,Season,Price,GenderId,ColorId,SizeId,MaterialId,Pattern,BrandId,CategoryId,Amount,Description,Picture")] Product product)
        {
            if (id != product.ProductId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.ProductId))
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
            ViewData["BrandId"] = new SelectList(_context.BrandTab, "BrandId", "BrandName", product.BrandId);
            ViewData["CategoryId"] = new SelectList(_context.CategoryTab, "CategoryId", "CategoryName", product.CategoryId);
            ViewData["ColorId"] = new SelectList(_context.ColorTab, "ColorId", "ColorName", product.ColorId);
            ViewData["GenderId"] = new SelectList(_context.GenderTab, "GenderId", "GenderName", product.GenderId);
            ViewData["MaterialId"] = new SelectList(_context.MaterialTab, "MaterialId", "MaterialName", product.MaterialId);
            ViewData["SizeId"] = new SelectList(_context.SizeTab, "SizeId", "SizeName", product.SizeId);
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .Include(p => p.Brand)
                .Include(p => p.Category)
                .Include(p => p.Color)
                .Include(p => p.Gender)
                .Include(p => p.Material)
                .Include(p => p.Size)
                .FirstOrDefaultAsync(m => m.ProductId == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await _context.Product.FindAsync(id);
            _context.Product.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductId == id);
        }
    }
}
