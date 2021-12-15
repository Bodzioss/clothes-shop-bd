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
    public class ProductsController : Controller
    {
        private readonly BD2SklepContext _context;

        public ProductsController(BD2SklepContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            var bD2SklepContext = _context.Product.Include(p => p.Brand).Include(p => p.Category).Include(p => p.Color).Include(p => p.Gender).Include(p => p.Material).Include(p => p.Size);
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

        // GET: Products/Create
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
