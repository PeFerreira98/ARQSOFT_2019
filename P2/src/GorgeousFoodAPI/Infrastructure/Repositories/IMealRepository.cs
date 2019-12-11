using GorgeousFoodAPI.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GorgeousFoodAPI.Infrastructure.Repositories
{
    public interface IMealRepository
    {
        IEnumerable<Meal> GetAllMeal();
        Task<Meal> GetMealByIDAsync(long id);
        Task EditMealAsync(Meal meal);
        Task AddMealAsync(Meal meal);
        Task DeleteMealAsync(Meal meal);

        bool MealExists(long id);
    }
}