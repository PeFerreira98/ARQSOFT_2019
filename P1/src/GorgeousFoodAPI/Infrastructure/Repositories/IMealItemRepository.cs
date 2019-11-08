using GorgeousFoodAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GorgeousFoodAPI.Infrastructure.Repositories
{
    public interface IMealItemRepository
    {
        IEnumerable<MealItem> GetAllMealItem();
        IEnumerable<MealItem> GetAllAvailableMealItem();
        Task<MealItem> GetMealItemByIDAsync(long id);
        Task EditMealItemAsync(MealItem mealItem);
        Task AddMealItemAsync(MealItem mealItem);
        Task DeleteMealItemAsync(MealItem mealItem);
        Task DisableMealItemAsync(long id);

        bool MealItemExists(long id);
    }
}
