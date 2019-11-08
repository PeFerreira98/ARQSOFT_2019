using GorgeousFoodAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GorgeousFoodAPI.Infrastructure.Repositories
{
    public class MealItemRepository : IMealItemRepository
    {
        private readonly GorgeousFoodMealContext _context;

        public MealItemRepository(GorgeousFoodMealContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));


        public IEnumerable<MealItem> GetAllMealItem() => _context.MealItem;

        public IEnumerable<MealItem> GetAllAvailableMealItem() => _context.MealItem.Where(x => x.AvailableStatus);

        public async Task<MealItem> GetMealItemByIDAsync(long id) => await _context.MealItem.FindAsync(id);

        public async Task EditMealItemAsync(MealItem mealItem)
        {
            _context.Entry(mealItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddMealItemAsync(MealItem mealItem)
        {
            _context.MealItem.Add(mealItem);
            await _context.SaveChangesAsync();

            //Instantiate GeneratedID
            var savedMealItem = await _context.MealItem.Include(x => x.Meal).Where(x => x.MealItemID == mealItem.MealItemID).SingleOrDefaultAsync();

            if (savedMealItem == null)
                return;

            savedMealItem.InstantiateMealIDNumber();
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMealItemAsync(MealItem mealItem)
        {
            _context.MealItem.Remove(mealItem);
            await _context.SaveChangesAsync();
        }

        public async Task DisableMealItemAsync(long id)
        {
            var mealItem = await GetMealItemByIDAsync(id);

            if (mealItem == null)
                return;

            mealItem.DisableMealItem();
            await _context.SaveChangesAsync();
        }

        public bool MealItemExists(long id) => _context.MealItem.Any(e => e.MealItemID == id);
    }
}
