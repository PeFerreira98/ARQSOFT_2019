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
    public class MealController : ControllerBase
    {
        private readonly IMealRepository _mealRepository;

        public MealController(IMealRepository mealRepository) => _mealRepository = mealRepository;


        // GET: api/Meal
        [HttpGet]
        public IEnumerable<Meal> GetMeal() => _mealRepository.GetAllMeal();

        // GET: api/Meal/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeal([FromRoute] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Meal meal = await _mealRepository.GetMealByIDAsync(id);

            return meal == null ? NotFound() : (IActionResult)Ok(meal);
        }

        // PUT: api/Meal/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeal([FromRoute] long id, [FromBody] Meal meal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != meal.MealID)
                return BadRequest();

            try
            {
                await _mealRepository.EditMealAsync(meal);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MealExists(id))
                    return NotFound();
                else
                    throw;
            }

            return NoContent();
        }

        // POST: api/Meal
        [HttpPost]
        public async Task<IActionResult> PostMeal([FromBody] Meal meal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _mealRepository.AddMealAsync(meal);

            return CreatedAtAction("GetMeal", new { id = meal.MealID }, meal);
        }

        // DELETE: api/Meal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal([FromRoute] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Meal meal = await _mealRepository.GetMealByIDAsync(id);

            if (meal == null)
                return NotFound();

            await _mealRepository.DeleteMealAsync(meal);

            return Ok(meal);
        }

        private bool MealExists(long id) => _mealRepository.MealExists(id);
    }
}