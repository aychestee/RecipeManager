using Microsoft.EntityFrameworkCore;
using RecipeManager.Models;

namespace RecipeManager.Data
{
    public class RecipeDatabaseContext : DbContext
    {
        public RecipeDatabaseContext(DbContextOptions<RecipeDatabaseContext> options) : base(options) { }

        public DbSet<Recipe> Recipe { get; set; }
    }
}
