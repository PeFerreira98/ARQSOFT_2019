using GorgeousFoodAPI.Infrastructure.Repositories;
using GorgeousFoodAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GorgeousFoodAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MealItemController : ControllerBase
    {
        private readonly IMealItemRepository _mealItemRepository;

        public MealItemController(IMealItemRepository mealItemRepository) => _mealItemRepository = mealItemRepository;

        // GET: api/MealItem
        [HttpGet]
        public IEnumerable<MealItem> GetMealItem() => _mealItemRepository.GetAllAvailableMealItem(); // _mealItemRepository.GetAllMealItem();

        // GET: api/MealItem/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMealItem([FromRoute] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            MealItem mealItem = await _mealItemRepository.GetMealItemByIDAsync(id);

            return mealItem == null ? NotFound() : (IActionResult)Ok(mealItem);
        }

        // PUT: api/MealItem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMealItem([FromRoute] long id, [FromBody] MealItem mealItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != mealItem.MealItemID)
                return BadRequest();

            try
            {
                await _mealItemRepository.EditMealItemAsync(mealItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealItemExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // POST: api/MealItem
        [HttpPost]
        public async Task<IActionResult> PostMealItem([FromBody] MealItem mealItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _mealItemRepository.AddMealItemAsync(mealItem);

            return CreatedAtAction("GetMealItem", new { id = mealItem.MealItemID }, mealItem);
        }

        // DELETE: api/MealItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMealItem([FromRoute] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            MealItem mealItem = await _mealItemRepository.GetMealItemByIDAsync(id);

            if (mealItem == null)
                return NotFound();

            await _mealItemRepository.DeleteMealItemAsync(mealItem);

            return Ok(mealItem);
        }

        private bool MealItemExists(long id) => _mealItemRepository.MealItemExists(id);
    }
}