using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.Difficulties;

namespace Tastebook.WebApp.Pages.Difficulties
{
    public class RetrieveAllModel : PageModel
    {
        private readonly IDifficultyService _difficultyService;

        public RetrieveAllModel(IDifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }

        public List<Difficulty> difficulties { get; set; }

        public void OnGet()
        {
            difficulties = _difficultyService.RetrieveAll();
        }

        public void OnPost()
        {
            Difficulty difficulty = new Difficulty();
            difficulty.Name = Convert.ToString(Request.Form["name"]);
            _difficultyService.Create(difficulty);
            difficulties = _difficultyService.RetrieveAll();
        }
    }
}
