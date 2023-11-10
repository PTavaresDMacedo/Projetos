using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Service.Ingredients;

namespace Tastebook.WebApp.Pages.Ingredients
{
    public class DeleteModel : PageModel
    {
        private readonly IIngredientService _ingredientService;

        public DeleteModel(IIngredientService ingredientService)
        {
            _ingredientService = ingredientService;
        }

        public IActionResult OnGet(int id)
        {
            _ingredientService.Delete(id);
            return Redirect("/Ingredients/RetrieveAll");
        }
    }
}
