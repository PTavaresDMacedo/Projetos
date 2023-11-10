using Receitas.Model;

namespace Receitas.Repository.Ingredients
{
    public interface IIngredientRepository
    {
        Ingredient Create(Ingredient ingredient);
        Ingredient Update(Ingredient ingredient);
        Ingredient Retrieve (int id);
        Ingredient Retrieve (string name);
        List<Ingredient> RetrieveAll ();
        void Delete (int id);

    }
}
