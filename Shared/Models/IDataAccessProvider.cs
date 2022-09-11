using System.Collections.Generic;

namespace CKSummary.Shared.Models
{
    public interface IDataAccessProvider
    {
        void AddRecipe(Recipe recipe);

        void UpdateRecipe(Recipe recipe);

        void DeleteRecipe(int id);

        Recipe GetRecipe(int id);

        List<Recipe> GetRecipeList();
        List<Recipe> FilterByItems(Dictionary<string, List<string>> vals);

        IEnumerable<Ingredient> GetAllIngredients();

        IEnumerable<Tag> GetAllTags();
    }
}