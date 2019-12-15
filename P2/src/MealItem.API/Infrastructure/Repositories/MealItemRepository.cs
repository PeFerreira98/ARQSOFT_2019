using GorgeousFood.MealItem.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GorgeousFood.MealItem.API.Infrastructure.Repositories
{
    public class MealItemRepository : IMealItemRepository
    {
        private readonly GorgeousFoodContext _context;

        public MealItemRepository(GorgeousFoodContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));


        public IEnumerable<Models.MealItem> GetAllMealItem() => _context.MealItem;

        public IEnumerable<Models.MealItem> GetAllAvailableMealItem() => _context.MealItem.Where(x => x.AvailableStatus);

        public async Task<Models.MealItem> GetMealItemByIDAsync(long id) => await _context.MealItem.FindAsync(id);

        public async Task EditMealItemAsync(Models.MealItem mealItem)
        {
            _context.Entry(mealItem).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddMealItemAsync(Models.MealItem mealItem)
        {
            _context.MealItem.Add(mealItem);
            await _context.SaveChangesAsync();

            //Instantiate GeneratedID
            var savedMealItem = await _context.MealItem.Where(x => x.MealItemID == mealItem.MealItemID).SingleOrDefaultAsync();

            if (savedMealItem == null)
                return;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteMealItemAsync(Models.MealItem mealItem)
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

        public async Task DisableMealItemAsync(Models.MealItem mealItem)
        {
            mealItem.DisableMealItem();
            await _context.SaveChangesAsync();
        }

        public bool MealItemExists(long id) => _context.MealItem.Any(e => e.MealItemID == id);
    }
}
