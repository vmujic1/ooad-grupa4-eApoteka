using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Apoteka.Data;
using E_Apoteka.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace E_Apoteka.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Products
        public async Task<IActionResult> Index(double? minPrice, double? maxPrice, string category, string search, string sort)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Product' is null.");
            }

            var productIds = await _context.Product.Select(p => p.Id).ToListAsync();

            var categoryIds = await _context.ProductCategory
                .Where(mc => productIds.Contains(mc.ProductId))
                .Select(mc => mc.CategoryId)
                .ToListAsync();

            var categories = await _context.Category.Select(c => c.Name).ToListAsync();

            var productCategories = await _context.ProductCategory
                .Include(pc => pc.Product)
                .Include(pc => pc.Category)
                .Where(pc => productIds.Contains(pc.ProductId) && categoryIds.Contains(pc.CategoryId))
                .ToListAsync();

            ViewBag.Categories = categories;

            var manufacturerIds = productCategories.Select(pc => pc.Product.ManufacturerId).Distinct().ToList();
            var manufacturers = await _context.Manufacturer
                .Where(m => manufacturerIds.Contains(m.Id))
                .ToListAsync();

            ViewBag.Manufacturers = manufacturers;

            var commentIds = await _context.Comment.Select(c => c.Id).Where().ToListAsync();
            var manufacturers = await _context.Manufacturer
                .Where(m => manufacturerIds.Contains(m.Id))
                .ToListAsync();

            ViewBag.Manufacturers = manufacturers;

            if (minPrice.HasValue && maxPrice.HasValue)
            {
                productCategories = productCategories.Where(pc => pc.Product.Price >= minPrice && pc.Product.Price <= maxPrice).ToList();
            }

            if (!string.IsNullOrEmpty(category))
            {
                productCategories = productCategories.Where(pc => pc.Category.Name.Equals(category, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            if (!string.IsNullOrEmpty(search))
            {
                productCategories = productCategories.Where(pc => pc.Product.Name.IndexOf(search, StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            }

            if (!string.IsNullOrEmpty(sort))
            {
                switch (sort)
                {
                    case "rating_asc":
                        productCategories = productCategories.OrderBy(pc => pc.Product.Rating).ToList();
                        break;
                    case "rating_desc":
                        productCategories = productCategories.OrderByDescending(pc => pc.Product.Rating).ToList();
                        break;
                    case "name_asc":
                        productCategories = productCategories.OrderBy(pc => pc.Product.Name).ToList();
                        break;
                    case "name_desc":
                        productCategories = productCategories.OrderByDescending(pc => pc.Product.Name).ToList();
                        break;
                    default:
                        break;
                }
            }

            return View(productCategories);
        }





        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        // GET: Products/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,ManufacturerId,Price,Rating,Stock,CategoryId,Description,ImageUrl")] Product product)
        {
            product.Manufacturer = await _context.Manufacturer.FindAsync(product.ManufacturerId);
            product.Category = await _context.Category.FindAsync(product.CategoryId);

            if (ModelState.IsValid)
            {
                _context.Add(product);
                await _context.SaveChangesAsync();

                // Create a new ProductCategory record
                var productCategory = new ProductCategory
                {
                    ProductId = product.Id,
                    CategoryId = product.CategoryId
                };
                _context.Add(productCategory);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }


        // GET: Products/Edit/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ManufacturerId,Price,Rating,Stock,CategoryId,Description,ImageUrl")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    product.Manufacturer = _context.Find<Manufacturer>(product.ManufacturerId);
                    product.Category = _context.Find<Category>(product.CategoryId);
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            return View(product);
        }

        // GET: Products/Delete/5
        [Authorize(Roles = "Administrator")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
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
            if (_context.Product == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Product'  is null.");
            }
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.Product.Remove(product);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

     


        private bool ProductExists(int id)
        {
          return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
