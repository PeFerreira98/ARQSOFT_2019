using GorgeousFoodAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GorgeousFoodAPI.Infrastructure
{
    public class GorgeousFoodMealContext : DbContext
    {
        public GorgeousFoodMealContext(DbContextOptions<GorgeousFoodMealContext> options)
            : base(options)
        {
        }

        public DbSet<Meal> Meal { get; set; }

        public DbSet<MealItem> MealItem { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Meal>().HasKey(c => c.MealID);
            modelBuilder.Entity<Meal>().Property(b => b.MealID).ValueGeneratedOnAdd();

            modelBuilder.Entity<MealItem>().HasKey(c => c.MealItemID);
            modelBuilder.Entity<MealItem>().Property(b => b.MealItemID).ValueGeneratedOnAdd();
        }
    }
}
