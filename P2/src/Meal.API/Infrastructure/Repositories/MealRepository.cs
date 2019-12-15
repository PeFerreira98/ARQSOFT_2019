using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GorgeousFood.Meal.API.Infrastructure.Repositories
{
    public class MealRepository : IMealRepository
    {
        private readonly GorgeousFoodContext _context;

        public MealRepository(GorgeousFoodContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));


        public IEnumerable<Models.Meal> GetAllMeal() => _context.Meal;

        public async Task<Models.Meal> GetMealByIDAsync(long id) => await _context.Meal.FindAsync(id);

        public async Task EditMealAsync(Models.Meal meal)
        {
            _context.Entry(meal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddMealAsync(Models.Meal meal)
        {
            _context.Meal.Add(meal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMealAsync(Models.Meal meal)
        {
            _context.Meal.Remove(meal);
            await _context.SaveChangesAsync();
        }

        public bool MealExists(long id) => _context.Meal.Any(e => e.MealID == id);
    }
}
