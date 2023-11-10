using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Service.Difficulties;

namespace Tastebook.WebApp.Pages.Difficulties
{
    public class DeleteModel : PageModel
    {
        private readonly IDifficultyService _difficultyService;

        public DeleteModel(IDifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }

        public IActionResult OnGet(int id)
        {
            _difficultyService.Delete(id);
            return Redirect("/Difficulties/RetrieveAll");
        }
    }
}
