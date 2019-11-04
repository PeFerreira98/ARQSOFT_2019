using GorgeousFoodAPI.Infrastructure;
using GorgeousFoodAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GorgeousFoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealItemController : ControllerBase
    {
        private readonly GorgeousFoodMealContext _context;

        public MealItemController(GorgeousFoodMealContext context)
        {
            _context = context;
        }

        // GET: api/MealItem
        [HttpGet]
        public IEnumerable<MealItem> GetMealItem()
        {
            return _context.MealItem.Include(x => x.Meal);
        }

        // GET: api/MealItem/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMealItem([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MealItem mealItem = await _context.MealItem.FindAsync(id);

            if (mealItem == null)
            {
                return NotFound();
            }

            return Ok(mealItem);
        }

        // PUT: api/MealItem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMealItem([FromRoute] long id, [FromBody] MealItem mealItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mealItem.MealItemID)
            {
                return BadRequest();
            }

            _context.Entry(mealItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealItemExists(id))
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

        // POST: api/MealItem
        [HttpPost]
        public async Task<IActionResult> PostMealItem([FromBody] MealItem mealItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.MealItem.Add(mealItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMealItem", new { id = mealItem.MealItemID }, mealItem);
        }

        // DELETE: api/MealItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMealItem([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MealItem mealItem = await _context.MealItem.FindAsync(id);
            if (mealItem == null)
            {
                return NotFound();
            }

            _context.MealItem.Remove(mealItem);
            await _context.SaveChangesAsync();

            return Ok(mealItem);
        }

        private bool MealItemExists(long id)
        {
            return _context.MealItem.Any(e => e.MealItemID == id);
        }
    }
}