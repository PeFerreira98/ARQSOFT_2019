using GorgeousFood.MealItem.API.DTOs;
using GorgeousFood.MealItem.API.Infrastructure.Repositories;
using GorgeousFood.MealItem.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GorgeousFood.MealItem.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MealItemController : ControllerBase
    {
        private readonly IMealItemRepository _mealItemRepository;

        public MealItemController(IMealItemRepository mealItemRepository) => _mealItemRepository = mealItemRepository;

        // GET: MealItem
        [HttpGet]
        public IEnumerable<Models.MealItem> GetMealItem() => _mealItemRepository.GetAllAvailableMealItem(); // _mealItemRepository.GetAllMealItem();

        // GET: MealItem/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMealItem([FromRoute] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Models.MealItem mealItem = await _mealItemRepository.GetMealItemByIDAsync(id);

            return mealItem == null ? NotFound() : (IActionResult)Ok(mealItem);
        }

        // GET: MealItem/grouped
        [HttpGet("grouped")]
        public IEnumerable<GroupedMealItem> GetGroupedMealItem()
        {
            //var mealitems = _mealItemRepository.GetGroupedMealItems();

            //var groupList = new List<(GroupedMealItem, long)>();

            //foreach (var item in mealitems)
            //    groupList.Add((item, _mealItemRepository.GetGroupedMealItemQuantity(item)));

            //return groupList;

            return _mealItemRepository.Stuff();
        }

        // GET: MealItem/exists/5
        [HttpGet("exists/{id}")]
        public bool MealItemExists([FromRoute] long id) => _mealItemRepository.MealItemExists(id);

        // PUT: MealItem/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMealItem([FromRoute] long id, [FromBody] Models.MealItem mealItem)
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

        // POST: MealItem
        [HttpPost]
        public async Task<IActionResult> PostMealItem([FromBody] Models.MealItem mealItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _mealItemRepository.AddMealItemAsync(mealItem);

            return CreatedAtAction("GetMealItem", new { id = mealItem.MealItemID }, mealItem);
        }

        // POST: MealItem/many/{number}
        [HttpPost("many/{number}")]
        public async Task<IActionResult> PostMealItemMany([FromRoute] long number, [FromBody] Models.MealItem mealItem)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            for (int i = 0; i < number; i++)
                await _mealItemRepository.AddMealItemAsync(mealItem);

            return CreatedAtAction("GetMealItem", new { id = mealItem.MealItemID }, mealItem);
        }

        // DELETE: MealItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMealItem([FromRoute] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Models.MealItem mealItem = await _mealItemRepository.GetMealItemByIDAsync(id);

            if (mealItem == null)
                return NotFound();

            await _mealItemRepository.DisableMealItemAsync(mealItem);

            return Ok(mealItem);
        }

        // POST: MealItem/5
        [HttpPost("{id}")]
        public async Task<IActionResult> DeleteMealItem2([FromRoute] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Models.MealItem mealItem = await _mealItemRepository.GetMealItemByIDAsync(id);

            if (mealItem == null)
                return NotFound();

            await _mealItemRepository.DisableMealItemAsync(mealItem);

            return Ok(mealItem);
        }
    }
}