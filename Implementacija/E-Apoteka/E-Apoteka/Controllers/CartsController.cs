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
    [Authorize]
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
               var cart = await _context.Cart.FirstOrDefaultAsync(c => c.UserId == user.Id);
            var productCarts = _context.ProductCart.Include(pc => pc.Product).Where(pc => pc.CartId == cart.Id).ToList();
                return View(productCarts);
        }

        /*public async Task<IActionResult> AddToCart(Product product)
        {
            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if user is not authenticated
            }

            Cart cart = await GetOrCreateCart(user);
            ProductCart productCart = new ProductCart()
            {
                ProductId = product.Id,
                CartId = cart.Id,
                Quantity = 1 // Set the desired quantity
            };

            _context.ProductCart.Add(productCart);
            await _context.SaveChangesAsync();
            

            return RedirectToAction("ViewCart");
        }


        public async Task<IActionResult> EmptyCart()
        {
            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if user is not authenticated
            }

            Cart cart = await GetOrCreateCart(user);

            // Find all ProductCart entries associated with the given cart
            IQueryable<ProductCart> productCarts = _context.ProductCart.Where(pc => pc.CartId == cart.Id);

            // Remove the found ProductCart entries from the database
            _context.ProductCart.RemoveRange(productCarts);

            await _context.SaveChangesAsync();
            

            return RedirectToAction("ViewCart");
        }


        public async Task<IActionResult> RemoveFromCart(Product product)
        {
            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if user is not authenticated
            }

            Cart cart = await GetOrCreateCart(user);


            // Find the specific ProductCart entry for the given product and cart
            ProductCart? productCart = _context.ProductCart.FirstOrDefault(pc => pc.ProductId == product.Id && pc.CartId == cart.Id);

            if (productCart != null)
            {
                // Remove the found ProductCart entry from the database
                _context.ProductCart.Remove(productCart);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("ViewCart");
        }

        public async Task<IActionResult> EditAmount(Product product, int amount)
        {
            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "Account"); // Redirect to login if user is not authenticated
            }

            Cart cart = await GetOrCreateCart(user);


            // Find the specific ProductCart entry for the given product and cart
            ProductCart? productCart = _context.ProductCart.FirstOrDefault(pc => pc.ProductId == product.Id && pc.CartId == cart.Id);

            if (productCart != null)
            {
                // Update the quantity of the ProductCart entry
                productCart.Quantity = amount;
                await _context.SaveChangesAsync();
            }
            

            return RedirectToAction("ViewCart");
        }


        private async Task<Cart> GetOrCreateCart(User user)
        {
            Cart cart = user.Cart;
            if (cart == null)
            {
                cart = new Cart()
                {
                    UserId = user.Id,
                    TotalPrice = 0 // Set the initial total price
                };

                // TODO: Save the cart to the database and associate it with the user

                user.Cart = cart;
                await _userManager.UpdateAsync(user);
            }

            return cart;
        }
        */
    }



    //    // GET: Carts
    //    public async Task<IActionResult> Index()
    //    {
    //        var applicationDbContext = _context.Cart.Include(c => c.User);
    //        return View(await applicationDbContext.ToListAsync());
    //    }

    //    // GET: Carts/Details/5
    //    public async Task<IActionResult> Details(int? id)
    //    {
    //        if (id == null || _context.Cart == null)
    //        {
    //            return NotFound();
    //        }

    //        var cart = await _context.Cart
    //            .Include(c => c.User)
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (cart == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(cart);
    //    }

    //    // GET: Carts/Create
    //    public IActionResult Create()
    //    {
    //        ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id");
    //        return View();
    //    }

    //    // POST: Carts/Create
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Create([Bind("Id,UserId,TotalPrice")] Cart cart)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            _context.Add(cart);
    //            await _context.SaveChangesAsync();
    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id", cart.UserId);
    //        return View(cart);
    //    }

    //    // GET: Carts/Edit/5
    //    public async Task<IActionResult> Edit(int? id)
    //    {
    //        if (id == null || _context.Cart == null)
    //        {
    //            return NotFound();
    //        }

    //        var cart = await _context.Cart.FindAsync(id);
    //        if (cart == null)
    //        {
    //            return NotFound();
    //        }
    //        ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id", cart.UserId);
    //        return View(cart);
    //    }

    //    // POST: Carts/Edit/5
    //    // To protect from overposting attacks, enable the specific properties you want to bind to.
    //    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    //    [HttpPost]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> Edit(int id, [Bind("Id,UserId,TotalPrice")] Cart cart)
    //    {
    //        if (id != cart.Id)
    //        {
    //            return NotFound();
    //        }

    //        if (ModelState.IsValid)
    //        {
    //            try
    //            {
    //                _context.Update(cart);
    //                await _context.SaveChangesAsync();
    //            }
    //            catch (DbUpdateConcurrencyException)
    //            {
    //                if (!CartExists(cart.Id))
    //                {
    //                    return NotFound();
    //                }
    //                else
    //                {
    //                    throw;
    //                }
    //            }
    //            return RedirectToAction(nameof(Index));
    //        }
    //        ViewData["UserId"] = new SelectList(_context.Set<User>(), "Id", "Id", cart.UserId);
    //        return View(cart);
    //    }

    //    // GET: Carts/Delete/5
    //    public async Task<IActionResult> Delete(int? id)
    //    {
    //        if (id == null || _context.Cart == null)
    //        {
    //            return NotFound();
    //        }

    //        var cart = await _context.Cart
    //            .Include(c => c.User)
    //            .FirstOrDefaultAsync(m => m.Id == id);
    //        if (cart == null)
    //        {
    //            return NotFound();
    //        }

    //        return View(cart);
    //    }

    //    // POST: Carts/Delete/5
    //    [HttpPost, ActionName("Delete")]
    //    [ValidateAntiForgeryToken]
    //    public async Task<IActionResult> DeleteConfirmed(int id)
    //    {
    //        if (_context.Cart == null)
    //        {
    //            return Problem("Entity set 'ApplicationDbContext.Cart'  is null.");
    //        }
    //        var cart = await _context.Cart.FindAsync(id);
    //        if (cart != null)
    //        {
    //            _context.Cart.Remove(cart);
    //        }

    //        await _context.SaveChangesAsync();
    //        return RedirectToAction(nameof(Index));
    //    }

    //    private bool CartExists(int id)
    //    {
    //      return (_context.Cart?.Any(e => e.Id == id)).GetValueOrDefault();
    //    }
    //}
}