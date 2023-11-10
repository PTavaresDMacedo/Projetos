using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.Recipes;

namespace Tastebook.WebApp.Pages.Recipes
{
    public class CreateDescriptionModel : PageModel
    {
        private readonly IRecipeService _recipeService;

        public CreateDescriptionModel(IRecipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public Recipe Recipe { get; set; }

        public void OnGet(int id)
        {
            Recipe = _recipeService.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            Recipe recipe = new Recipe();
            recipe.Description = Convert.ToString(Request.Form["description"]);
            recipe = _recipeService.Update(recipe);

            return Redirect("/Recipes/RetrieveAll");
        }
    }

}
