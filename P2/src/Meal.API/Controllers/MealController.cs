using GorgeousFood.Meal.API.Infrastructure.Repositories;
using GorgeousFood.Meal.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GorgeousFood.Meal.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MealController : ControllerBase
    {
        private readonly IMealRepository _mealRepository;

        public MealController(IMealRepository mealRepository) => _mealRepository = mealRepository;


        // GET: /Meal
        [HttpGet]
        public IEnumerable<Models.Meal> GetMeal() => _mealRepository.GetAllMeal();

        // GET: /Meal/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMeal([FromRoute] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Models.Meal meal = await _mealRepository.GetMealByIDAsync(id);

            return meal == null ? NotFound() : (IActionResult)Ok(meal);
        }

        // PUT: /Meal/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMeal([FromRoute] long id, [FromBody] Models.Meal meal)
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

        // POST: /Meal
        [HttpPost]
        public async Task<IActionResult> PostMeal([FromBody] Models.Meal meal)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _mealRepository.AddMealAsync(meal);

            return CreatedAtAction("GetMeal", new { id = meal.MealID }, meal);
        }

        // DELETE: /Meal/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMeal([FromRoute] long id)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Models.Meal meal = await _mealRepository.GetMealByIDAsync(id);

            if (meal == null)
                return NotFound();

            await _mealRepository.DeleteMealAsync(meal);

            return Ok(meal);
        }

        private bool MealExists(long id) => _mealRepository.MealExists(id);
    }
}