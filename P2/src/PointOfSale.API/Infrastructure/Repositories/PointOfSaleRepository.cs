using GorgeousFood.PointOfSale.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GorgeousFood.PointOfSale.API.Infrastructure.Repositories
{
    public class PointOfSaleRepository : IPointOfSaleRepository
    {
        private readonly GorgeousFoodContext _context;

        public PointOfSaleRepository(GorgeousFoodContext context) => _context = context ?? throw new ArgumentNullException(nameof(context));


        public IEnumerable<Models.PointOfSale> GetAllPointOfSale() => _context.PointOfSale;

        public async Task<Models.PointOfSale> GetPointOfSaleByIDAsync(long id) => await _context.PointOfSale.FindAsync(id);

        public async Task EditPointOfSaleAsync(Models.PointOfSale pointOfSale)
        {
            _context.Entry(pointOfSale).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task AddPointOfSaleAsync(Models.PointOfSale pointOfSale)
        {
            _context.PointOfSale.Add(pointOfSale);
            await _context.SaveChangesAsync();

            //Instantiate GeneratedID
            var savedPointOfSale = await _context.PointOfSale.Where(x => x.PointOfSaleID == pointOfSale.PointOfSaleID).SingleOrDefaultAsync();

            if (savedPointOfSale == null)
                return;

            await _context.SaveChangesAsync();
        }

        public async Task DeletePointOfSaleAsync(Models.PointOfSale pointOfSale)
        {
            _context.PointOfSale.Remove(pointOfSale);
            await _context.SaveChangesAsync();
        }

        public bool PointOfSaleExists(long id) => _context.PointOfSale.Any(e => e.PointOfSaleID == id);
    }
}
