using Receitas.Model;
using Receitas.Repository.RecipeIngredients;
using Receitas.Service.Ingredients;
using Receitas.Service.Measures;

namespace Receitas.Service.RecipeIngredients
{
    public class RecipeIngredientService : IRecipeIngredientService
    {
        private readonly IRecipeIngredientsRepository _recipeIngredientsRepository;
        private readonly IIngredientService _ingredientService;
        private readonly IMeasureService _measureService;

        public RecipeIngredientService(IRecipeIngredientsRepository recipeIngredientsRepository, IIngredientService ingredientService, IMeasureService measureService)
        {
            _recipeIngredientsRepository = recipeIngredientsRepository;
            _ingredientService = ingredientService;
            _measureService = measureService;
        }

        public RecipeIngredient Create(RecipeIngredient recipeIngredients)
        {
            return _recipeIngredientsRepository.Create(recipeIngredients);
        }

        public void Delete(int id)
        {
            _recipeIngredientsRepository.Delete(id);
        }

        public void DeleteAllByRecipeId(int recipeId)
        {
            _recipeIngredientsRepository.DeleteAllByRecipeId(recipeId);
        }

        public RecipeIngredient Retrieve(int id)
        {
            RecipeIngredient recipeIngredient = _recipeIngredientsRepository.Retrieve(id);
            recipeIngredient.Ingredient = _ingredientService.Retrieve(recipeIngredient.Ingredient.Id);
            recipeIngredient.Measure = _measureService.Retrieve(recipeIngredient.Measure.Id);
            return recipeIngredient;
        }

        public List<RecipeIngredient> RetrieveAllByRecipeId(int recipeId)
        {
            List<RecipeIngredient> recipeIngredients = _recipeIngredientsRepository.RetrieveAllByRecipeId(recipeId);

            foreach (RecipeIngredient ingredient in recipeIngredients)
            {
                ingredient.Ingredient = _ingredientService.Retrieve(ingredient.Ingredient.Id);
                ingredient.Measure = _measureService.Retrieve(ingredient.Measure.Id);
            }
            return recipeIngredients;
        }
    }
}
