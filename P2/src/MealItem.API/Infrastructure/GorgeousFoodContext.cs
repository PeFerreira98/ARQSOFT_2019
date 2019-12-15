using GorgeousFood.MealItem.API.Models;
using Microsoft.EntityFrameworkCore;

namespace GorgeousFood.MealItem.API.Infrastructure
{
    public class GorgeousFoodContext : DbContext
    {
        public GorgeousFoodContext(DbContextOptions<GorgeousFoodContext> options)
            : base(options)
        {
        }

        public DbSet<Models.MealItem> MealItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.MealItem>().HasKey(c => c.MealItemID);
            modelBuilder.Entity<Models.MealItem>().Property(b => b.MealItemID).ValueGeneratedOnAdd();
        }
    }
}
