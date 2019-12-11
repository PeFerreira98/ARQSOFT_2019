using GorgeousFoodAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GorgeousFoodAPI.Infrastructure.Repositories
{
    public class MealRepository : IMealRepository
    {
        private readonly GorgeousFoodMealContext _context;

        public MealRepository(GorgeousFoodMealContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));


        public IEnumerable<Meal> GetAllMeal() => _context.Meal;

        public async Task<Meal> GetMealByIDAsync(long id) => await _context.Meal.FindAsync(id);

        public async Task EditMealAsync(Meal meal)
        {
            _context.Entry(meal).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddMealAsync(Meal meal)
        {
            _context.Meal.Add(meal);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMealAsync(Meal meal)
        {
            _context.Meal.Remove(meal);
            await _context.SaveChangesAsync();
        }

        public bool MealExists(long id) => _context.Meal.Any(e => e.MealID == id);
    }
}
