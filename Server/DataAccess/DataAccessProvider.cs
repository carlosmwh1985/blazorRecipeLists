using CKSummary.Shared.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.SqlClient;

namespace CKSummary.Server.DataAccess
{

    public class DataAccessProvider : IDataAccessProvider
    {
        public readonly DomainModelContext _context;
        public readonly ILogger _logger;

        public DataAccessProvider(DomainModelContext context, ILoggerFactory loggerFactory)
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("DataAccessProvider");
        }

        public void AddRecipe(Recipe recipe)
        {
            _context.Recipes.Add(recipe);
            _context.SaveChanges();
        }

        public void UpdateRecipe(Recipe recipe)
        {
            _context.Recipes.Update(recipe);
            _context.SaveChanges();
        }

        public void DeleteRecipe(int id)
        {
            var entity = _context.Recipes.First(r => r.Id == id);
            _context.Recipes.Remove(entity);
            _context.SaveChanges();
        }

        public Recipe GetRecipe(int id)
        {
            return _context.Recipes.First(r => r.Id == id);
        }

        public List<Recipe> GetRecipeList()
        {
            return _context.Recipes.ToList();
        }

        public List<Recipe> FilterByItems(Dictionary<string, List<string>> vals)
        {
            string sqlRaw = QueryBuilder.ConfigureQuery(vals["ingredients"], vals["tags"]);
            _context.ExecuteRaw(sqlRaw);
            return _context.RecipesFiltered;
        }

        public IEnumerable<Ingredient> GetAllIngredients()
        {
            return _context.Ingredients.ToList();
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _context.Tags.ToList();
        }
    }
    
}