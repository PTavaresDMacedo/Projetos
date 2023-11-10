using Receitas.Model;
using Receitas.Repository.Ingredients;

namespace Receitas.Service.Ingredients
{
    public class IngredientService : IIngredientService
    {
        private readonly IIngredientRepository _ingredientRepository;
        public IngredientService(IIngredientRepository ingredientRepository)
        {
            this._ingredientRepository = ingredientRepository;
        }

        public Ingredient Create(Ingredient ingredient)
        {
            return _ingredientRepository.Create(ingredient);
        }

        public void Delete(int id)
        {
            _ingredientRepository.Delete(id);
        }

        public Ingredient Retrieve(int id)
        {
            return _ingredientRepository.Retrieve(id);
        }

        public Ingredient Retrieve(string name)
        {
            return _ingredientRepository.Retrieve(name);
        }

        public List<Ingredient> RetrieveAll()
        {
            return _ingredientRepository.RetrieveAll();
        }

        public Ingredient Update(Ingredient ingredient)
        {
            return _ingredientRepository.Update(ingredient);
        }
    }
}
