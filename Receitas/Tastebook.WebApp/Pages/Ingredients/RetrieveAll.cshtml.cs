using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.Ingredients;

namespace Tastebook.WebApp.Pages.Ingredients
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IIngredientService _ingredientService;

        public RetrieveAllModel(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public List<Ingredient> ingredients { get; set; }

        public void OnGet()
        {
            ingredients = _ingredientService.RetrieveAll();
        }

        public void OnPost()
        {
            Ingredient ingredient = new Ingredient();
            ingredient.Name = Convert.ToString(Request.Form["name"]);
            _ingredientService.Create(ingredient);
            ingredients = _ingredientService.RetrieveAll();
        }
    }
}
