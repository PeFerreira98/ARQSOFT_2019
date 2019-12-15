
using Microsoft.EntityFrameworkCore;

namespace GorgeousFood.Meal.API.Infrastructure
{
    public class GorgeousFoodContext : DbContext
    {
        public GorgeousFoodContext(DbContextOptions<GorgeousFoodContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Meal> Meal { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Meal>().HasKey(c => c.MealID);
            modelBuilder.Entity<Models.Meal>().Property(b => b.MealID).ValueGeneratedOnAdd();
        }
    }
}
