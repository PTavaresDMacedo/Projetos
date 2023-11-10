using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Service.Recipes;

namespace Tastebook.WebApp.Pages.Recipes
{
    public class DeleteModel : PageModel
    {
        private readonly IRecipeService _recipeService;

        public DeleteModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public IActionResult OnGet(int id)
        {
            _recipeService.Delete(id);
            return Redirect("/Recipes/RetrieveAll");
        }
    }
}
