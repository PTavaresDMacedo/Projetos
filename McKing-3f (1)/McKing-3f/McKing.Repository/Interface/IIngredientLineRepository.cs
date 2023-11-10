using McKing.Model;

namespace McKing.Repository.Interface
{
    public interface IIngredientLineRepository
    {
        IngredientLine Create(IngredientLine ingredientLine);
        IngredientLine Retrieve(int id);
        List<IngredientLine> RetrieveAllByRecipeId(int recipeId);
        void Delete(int id);
        void DeleteAllByRecipeId(int recipeId);
    }
}
