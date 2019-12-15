using System.Collections.Generic;
using System.Threading.Tasks;

namespace GorgeousFood.Meal.API.Infrastructure.Repositories
{
    public interface IMealRepository
    {
        IEnumerable<Models.Meal> GetAllMeal();
        Task<Models.Meal> GetMealByIDAsync(long id);
        Task EditMealAsync(Models.Meal meal);
        Task AddMealAsync(Models.Meal meal);
        Task DeleteMealAsync(Models.Meal meal);

        bool MealExists(long id);
    }
}