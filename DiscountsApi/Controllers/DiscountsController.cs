/* using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountsApi.Controllers
{
    public class DiscountsController
    {
        
    }
} */

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DiscountsApi.Models;
using DiscountsApi.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DiscountsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly DiscountsContext _context;

        public DiscountsController(DiscountsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Discount>>> GetDiscounts()
        {
            return await _context.Discounts.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Discount>> GetDiscount(int id)
        {
            var discount = await _context.Discounts.FindAsync(id);

            if (discount == null)
            {
                return NotFound();
            }

            return discount;
        }

        [HttpPost]
        public async Task<ActionResult<Discount>> PostDiscount(Discount discount)
        {
            _context.Discounts.Add(discount);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDiscount), new { id = discount.Id }, discount);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutDiscount(int id, Discount discount)
        {
            if (id != discount.Id)
            {
                return BadRequest();
            }

            _context.Entry(discount).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Discounts.Any(e => e.Id == id))
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDiscount(int id)
        {
            var discount = await _context.Discounts.FindAsync(id);
            if (discount == null)
            {
                return NotFound();
            }

            _context.Discounts.Remove(discount);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
