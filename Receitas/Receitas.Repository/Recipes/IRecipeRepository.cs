using Receitas.Model;

namespace Receitas.Repository.Recipes
{
    public interface IRecipeRepository
    {
        public Recipe Create(Recipe recipe);
        public Recipe Update(Recipe recipe);
        public Recipe Retrieve(int id);
        public Recipe Retrieve(string name);
        List<Recipe> RetrieveAll();
        void Delete(int id);
    }
}
