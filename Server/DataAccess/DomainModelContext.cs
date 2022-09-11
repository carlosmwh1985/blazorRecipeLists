using CKSummary.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace CKSummary.Server.DataAccess
{
    public class DomainModelContext : DbContext
    {
        public DbSet<Recipe> Recipes { get; set; }
        public List<Recipe> RecipesFiltered { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }

        public DbSet<Tag> Tags { get; set; }

        public DomainModelContext(DbContextOptions<DomainModelContext> options) : base (options)
        {
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseNpgsql(connectionString);
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();
            return base.SaveChanges();
        }

        public void ExecuteRaw(string sqlRaw)
        {
            RecipesFiltered = Recipes.FromSqlRaw(sqlRaw).ToList<Recipe>();
            // var tmp = Recipes.FromSqlRaw(sqlRaw);
            // RecipesFiltered = tmp;
        }
    }
}