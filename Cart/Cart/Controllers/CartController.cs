using Cart.Services;
using Microsoft.AspNetCore.Mvc;
using Cart.Models;

namespace Cart.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController(CartService cartService) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<List<Entities.Cart>>> Get()
        {
            try
            {
                var carts = await cartService.GetAsync();
                return Ok(carts);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { message = "An error occurred while fetching the carts.", details = ex.Message });
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<Entities.Cart>>> GetByUserId(string userId)
        {
            try
            {
                var carts = await cartService.GetByUserIdAsync(userId);
                return Ok(carts);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { message = "An error occurred while fetching the carts.", details = ex.Message });
            }
        }
        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Entities.Cart>> Get(string id)
        {
            try
            {
                var cart = await cartService.GetAsync(id);

                if (cart is null)
                {
                    return NotFound(new { message = "Cart not found." });
                }

                return Ok(cart);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { message = "An error occurred while fetching the cart.", details = ex.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Entities.Cart newCart)
        {
            try
            {
                newCart.Id = null;
                await cartService.CreateAsync(newCart);
                return CreatedAtAction(nameof(Get), new { id = newCart.Id }, newCart);
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { message = "An error occurred while creating the cart.", details = ex.Message });
            }
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Entities.Cart updatedCart)
        {
            try
            {
                var cart = await cartService.GetAsync(id);

                if (cart is null)
                {
                    return NotFound(new { message = "Cart not found." });
                }

                updatedCart.Id = cart.Id;

                await cartService.UpdateAsync(id, updatedCart);

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { message = "An error occurred while updating the cart.", details = ex.Message });
            }
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                var cart = await cartService.GetAsync(id);

                if (cart is null)
                {
                    return NotFound(new { message = "Cart not found." });
                }

                await cartService.RemoveAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {
                // Log the exception
                return StatusCode(500, new { message = "An error occurred while deleting the cart.", details = ex.Message });
            }
        }
    }
}
