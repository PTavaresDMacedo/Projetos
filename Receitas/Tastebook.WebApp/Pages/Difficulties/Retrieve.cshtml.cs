using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.Difficulties;

namespace Tastebook.WebApp.Pages.Difficulties
{
    public class RetrieveModel : PageModel
    {
        private readonly IDifficultyService _difficultyService;

        public RetrieveModel(IDifficultyService difficultyService)
        {
            _difficultyService = difficultyService;
        }

        public Difficulty Difficulty { get; set; }

        public void OnGet(int id)
        {
            Difficulty = _difficultyService.Retrieve(id);
        }
    }
}
