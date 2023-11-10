using Receitas.Model;

namespace Receitas.Service.RecipeIngredients
{
    public interface IRecipeIngredientService
    {
        RecipeIngredient Create(RecipeIngredient recipeIngredients);
        RecipeIngredient Retrieve(int id);
        List<RecipeIngredient> RetrieveAllByRecipeId(int recipeId);
        void Delete(int id);
        void DeleteAllByRecipeId(int recipeId);
    }
}
