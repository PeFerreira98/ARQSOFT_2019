using GorgeousFood.MealItem.API.DTOs;
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

        public IEnumerable<long> GetAllAvailableMealIDs() => _context.MealItem.Where(x => x.AvailableStatus).Select(x => x.MealID).Distinct();

        public IEnumerable<GroupedMealItem> GetGroupedMealItems() =>
            _context.MealItem
                .Where(x => x.AvailableStatus).OrderBy(x => x.PointOfSaleID).ThenBy(x => x.MealID).ThenBy(x => x.ProductionDate).ThenBy(x => x.ExpirationDate)
                .Select(x => new GroupedMealItem(x.PointOfSaleID, x.MealID, x.ProductionDate, x.ExpirationDate)).Distinct();

        public long GetGroupedMealItemQuantity(GroupedMealItem groupedMealItem) =>
            _context.MealItem
                .Where(x => x.AvailableStatus && x.PointOfSaleID == groupedMealItem.PointOfSaleID && x.MealID == groupedMealItem.MealID && x.ProductionDate == groupedMealItem.ProductionDate && x.ExpirationDate == groupedMealItem.ExpirationDate)
                .Count();

        public IEnumerable<GroupedMealItem> Stuff()
        {
            var stuff = _context.MealItem
                .Where(x => x.AvailableStatus).OrderBy(x => x.PointOfSaleID).ThenBy(x => x.MealID).ThenBy(x => x.ProductionDate).ThenBy(x => x.ExpirationDate)
                ;//.Select(x => new GroupedMealItem(x.PointOfSaleID, x.MealID, x.ProductionDate, x.ExpirationDate));

            var s2 = stuff.GroupBy(x => new GroupedMealItem(x.PointOfSaleID, x.MealID, x.ProductionDate, x.ExpirationDate)).Select(g => new GroupedMealItem(g.Key.PointOfSaleID, g.Key.MealID, g.Key.ProductionDate, g.Key.ExpirationDate, g.Count()));

            return s2;
        }

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

        public async Task AddManyMealItemAsync(long number, Models.MealItem mealItem)
        {
            for (int i = 0; i < number; i++)
                await AddMealItemAsync(mealItem);
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
