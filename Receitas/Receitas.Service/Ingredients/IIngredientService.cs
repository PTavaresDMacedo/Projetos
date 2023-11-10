using Receitas.Model;

namespace Receitas.Service.Ingredients
{
    public interface IIngredientService
    {
        Ingredient Create(Ingredient ingredient);
        Ingredient Update(Ingredient ingredient);
        Ingredient Retrieve(int id);
        Ingredient Retrieve(string name);
        List<Ingredient> RetrieveAll();
        void Delete(int id);
    }
}
