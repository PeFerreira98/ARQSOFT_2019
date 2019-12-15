using GorgeousFood.MealItem.API.DTOs;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GorgeousFood.MealItem.API.Infrastructure.Repositories
{
    public interface IMealItemRepository
    {
        IEnumerable<Models.MealItem> GetAllMealItem();
        IEnumerable<Models.MealItem> GetAllAvailableMealItem();
        Task<Models.MealItem> GetNextAvailableMealItemFromBatch(DateTime pDate, DateTime expDate, long mealID, long pointOfSaleID);
        IEnumerable<GroupedMealItem> GetGroupedMealItems();
        IEnumerable<GroupedMealItem> Stuff();
        long GetGroupedMealItemQuantity(GroupedMealItem groupedMealItem);
        Task<Models.MealItem> GetMealItemByIDAsync(long id);
        Task EditMealItemAsync(Models.MealItem mealItem);
        Task AddMealItemAsync(Models.MealItem mealItem);
        Task AddManyMealItemAsync(Models.MealItem mealItem, long number);
        Task AddManyMealItemAsync(long number, Models.MealItem mealItem);
        Task DeleteMealItemAsync(Models.MealItem mealItem);
        Task DisableMealItemAsync(long id);
        Task DisableMealItemAsync(Models.MealItem mealItem);

        bool MealItemExists(long id);
    }
}
