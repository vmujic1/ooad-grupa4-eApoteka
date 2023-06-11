using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using E_Apoteka.Data;
using E_Apoteka.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace E_Apoteka.Controllers
{
    [Authorize(Roles = "Administrator, User")]
    public class CartsController : Controller
    {
        private readonly ApplicationDbContext _context;
        

        public CartsController(ApplicationDbContext context)
        {
            _context = context;
        }


        /*public async Task<IActionResult> ViewCart()
        {
            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if user is not authenticated
            }

            Cart cart = await GetOrCreateCart(user);
            return View(cart);
        }
        */
        // GET: Carts
        
        public async Task<IActionResult> Index()
            {
               var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
               var cart = await _context.Cart.FirstOrDefaultAsync(c => c.UserId == user.Id && c.Bought == false);
            if (cart == null || !_context.ProductCart.Any())
            {
                // Cart is empty or null, display a popup or redirect to a specific page
                TempData["CartMessage"] = "Korpa je trenutno prazna!";
                return RedirectToAction("EmptyCart");
            }
            var productCarts = _context.ProductCart.Include(pc => pc.Product).Where(pc => pc.CartId == cart.Id).ToList();
                return View(productCarts);
        }

        // GET: Empty Cart
        public IActionResult EmptyCart()
        {
            ViewBag.Message = TempData["CartMessage"];
            return View();
        }


        // GET: Carts/Details/5
        public async Task<IActionResult> Details(int? id)
            {
                if (id == null || _context.Cart == null)
                {
                    return NotFound();
                }

                var cart = await _context.Cart
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(m => m.Id == id);
                if (cart == null)
                {
                    return NotFound();
                }

                return View(cart);
            }

        // GET: Carts/Create
        [Authorize(Roles = "Administrator")]
        public IActionResult Create()
            {
                ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id");
                return View();
            }

        // POST: Carts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator")]
        [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Create([Bind("Id,UserId,TotalPrice,Bought")] Cart cart)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(cart);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id", cart.UserId);
                return View(cart);
            }


        [HttpPost]
        public async Task<IActionResult> AddToCart(int id, int quantity)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
            var cart = await _context.Cart.FirstOrDefaultAsync(c => c.UserId == user.Id && c.Bought == false);

            if (cart == null)
            {
                var newCart = new Cart
                {
                    UserId = user.Id,
                    TotalPrice = 0.0,
                    Bought = false
                };

                await _context.Cart.AddAsync(newCart);
                await _context.SaveChangesAsync();

                var newProductCart = new ProductCart
                {
                    CartId = newCart.Id,
                    Quantity = quantity,
                    ProductId = id
                };

                await _context.ProductCart.AddAsync(newProductCart);
                await _context.SaveChangesAsync();
            }
            else
            {
                var existingProductCart = await _context.ProductCart
                    .FirstOrDefaultAsync(pc => pc.CartId == cart.Id && pc.ProductId == id);

                if (existingProductCart != null)
                {
                    existingProductCart.Quantity += quantity;
                }
                else
                {
                    var newProductCart = new ProductCart
                    {
                        CartId = cart.Id,
                        Quantity = quantity,
                        ProductId = id
                    };

                    await _context.ProductCart.AddAsync(newProductCart);
                }

                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Details", "Product", new { id = id });
        }

        // GET: Carts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cart == null)
            {
                return NotFound();
            }

            var cart = await _context.Cart.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id", cart.UserId);
            return View(cart);
        }

        // POST: Carts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,TotalPrice,Bought")] Cart cart)
        {
            if (id != cart.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cart);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CartExists(cart.Id))
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
            ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id", cart.UserId);
            return View(cart);
        }

        private bool CartExists(int id)
        {
            return (_context.Cart?.Any(e => e.Id == id)).GetValueOrDefault();
        }



        // GET: Carts/Delete/5
        public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.Cart == null)
        {
            return NotFound();
        }

        var cart = await _context.Cart
            .Include(c => c.User)
            .FirstOrDefaultAsync(m => m.Id == id);
        if (cart == null)
        {
            return NotFound();
        }

        return View(cart);
    }

    // POST: Carts/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.Cart == null)
        {
            return Problem("Entity set 'ApplicationDbContext.Cart'  is null.");
        }
        var cart = await _context.Cart.FindAsync(id);
        if (cart != null)
        {
            _context.Cart.Remove(cart);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

        //Post: Carts/ClearCart
        [HttpPost]
        public async Task<IActionResult> ClearCart()
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
            var cart = await _context.Cart.FirstOrDefaultAsync(c => c.UserId == user.Id && c.Bought == false);

            if (cart != null)
            {
                var productCartsToRemove = _context.ProductCart.Where(pc => pc.CartId == cart.Id);

                _context.ProductCart.RemoveRange(productCartsToRemove);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("Index", "Carts");
        }

        //Post: Carts/RemoveItem
        [HttpPost]
        public async Task<IActionResult> RemoveItem(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == User.Identity.Name);
            var cart = await _context.Cart.FirstOrDefaultAsync(c => c.UserId == user.Id && c.Bought == false);

            if (cart != null)
            {
                var productCarts = _context.ProductCart
                    .Where(pc => pc.CartId == cart.Id && pc.ProductId == id)
                    .ToList();

                if (productCarts.Any())
                {
                    _context.ProductCart.RemoveRange(productCarts);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction("Index", "Carts");
        }

    }
}