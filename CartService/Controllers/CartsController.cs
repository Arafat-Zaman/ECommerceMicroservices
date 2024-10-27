using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CartService.Data;
using CartService.Models;

namespace CartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartsController : ControllerBase
    {
        private readonly CartContext _context;

        public CartsController(CartContext context)
        {
            _context = context;
        }

        // Get all carts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cart>>> GetCarts()
        {
            return await _context.Carts.Include(c => c.Items).ToListAsync();
        }

        // Get a specific cart by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Cart>> GetCart(int id)
        {
            var cart = await _context.Carts.Include(c => c.Items).FirstOrDefaultAsync(c => c.Id == id);
            if (cart == null)
            {
                return NotFound();
            }

            return cart;
        }

        // Create a new cart
        [HttpPost]
        public async Task<ActionResult<Cart>> CreateCart(Cart cart)
        {
            _context.Carts.Add(cart);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCart), new { id = cart.Id }, cart);
        }

        // Update a cart
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCart(int id, Cart updatedCart)
        {
            if (id != updatedCart.Id)
            {
                return BadRequest();
            }

            _context.Entry(updatedCart).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Carts.Any(c => c.Id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // Delete a cart
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCart(int id)
        {
            var cart = await _context.Carts.FindAsync(id);
            if (cart == null)
            {
                return NotFound();
            }

            _context.Carts.Remove(cart);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
