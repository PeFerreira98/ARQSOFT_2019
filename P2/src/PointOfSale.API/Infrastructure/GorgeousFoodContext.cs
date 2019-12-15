using GorgeousFood.PointOfSale.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GorgeousFood.PointOfSale.API.Infrastructure
{
    public class GorgeousFoodContext : DbContext
    {
        public GorgeousFoodContext(DbContextOptions<GorgeousFoodContext> options)
            : base(options)
        {
        }

        public DbSet<Models.PointOfSale> PointOfSale { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.PointOfSale>().HasKey(c => c.PointOfSaleID);
            modelBuilder.Entity<Models.PointOfSale>().Property(b => b.PointOfSaleID).ValueGeneratedOnAdd();
        }
    }
}
