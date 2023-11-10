using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.Difficulties;

namespace Tastebook.WebApp.Pages.Difficulties
{
    public class UpdateModel : PageModel
    {
        private readonly IDifficultyService _difficultyService;

        public UpdateModel(IDifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }

        public Difficulty Difficulty { get; set; }

        public void OnGet(int id)
        {
            Difficulty = _difficultyService.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            Difficulty difficulty = new Difficulty();
            difficulty.Id = Convert.ToInt32(Request.Form["id"]);
            difficulty.Name = Convert.ToString(Request.Form["name"]);
            _difficultyService.Update(difficulty);
            return Redirect("/Difficulties/RetrieveAll");
        }
    }
}
