using McKing.Model;

namespace McKing.Service.Interface
{
    public interface IIngredientLineService
    {
        IngredientLine Create(IngredientLine ingredientLine);
        IngredientLine Retrieve(int id);
        List<IngredientLine> RetrieveAllByRecipeId(int recipeId);
        void DeleteAllByRecipeId(int recipeId);
        void Delete(int id);
    }
}
