using McKing.Model;
using McKing.Repository.Interface;
using McKing.Service.Interface;

namespace McKing.Service.Implementation
{
    public class IngredientLineService : IIngredientLineService
    {
        private readonly IIngredientLineRepository _repository;
        private readonly IService<Ingredient, int> _ingredientService;
        private readonly IService<Measure, int> _measureService;

        public IngredientLineService(IIngredientLineRepository repository, IService<Ingredient, int> ingredientService, IService<Measure, int> measureService)
        {
            _repository = repository;
            _ingredientService = ingredientService;
            _measureService = measureService;
        }

        public IngredientLine Create(IngredientLine ingredientLine)
        {
            return _repository.Create(ingredientLine);
        }

        public void DeleteAllByRecipeId(int recipeId)
        {
            _repository.DeleteAllByRecipeId(recipeId);
        }

        public void Delete(int id)
        {
            _repository.Delete(id);
        }

        public IngredientLine Retrieve(int id)
        {
            IngredientLine ingredientLine = _repository.Retrieve(id);
            ingredientLine.Ingredient = _ingredientService.Retrieve(ingredientLine.Ingredient.Id);
            ingredientLine.Measure = _measureService.Retrieve(ingredientLine.Measure.Id);
            return ingredientLine;
        }

        public List<IngredientLine> RetrieveAllByRecipeId(int recipeId)
        {
            List<IngredientLine> ingredientLines = _repository.RetrieveAllByRecipeId(recipeId);

            foreach (IngredientLine ingredientLine in ingredientLines)
            {
                ingredientLine.Ingredient = _ingredientService.Retrieve(ingredientLine.Ingredient.Id);
                ingredientLine.Measure = _measureService.Retrieve(ingredientLine.Measure.Id);
            }

            return ingredientLines;
        }
    }
}
