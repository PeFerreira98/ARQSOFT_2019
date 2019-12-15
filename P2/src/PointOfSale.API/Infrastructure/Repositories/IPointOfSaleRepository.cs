using System.Collections.Generic;
using System.Threading.Tasks;

namespace GorgeousFood.PointOfSale.API.Infrastructure.Repositories
{
    public interface IPointOfSaleRepository
    {
        IEnumerable<Models.PointOfSale> GetAllPointOfSale();
        Task<Models.PointOfSale> GetPointOfSaleByIDAsync(long id);
        Task EditPointOfSaleAsync(Models.PointOfSale pointOfSale);
        Task AddPointOfSaleAsync(Models.PointOfSale pointOfSale);
        Task DeletePointOfSaleAsync(Models.PointOfSale pointOfSale);

        bool PointOfSaleExists(long id);
    }
}
