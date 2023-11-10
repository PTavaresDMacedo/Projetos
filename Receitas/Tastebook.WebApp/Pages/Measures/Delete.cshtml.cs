using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Service.Measures;

namespace Tastebook.WebApp.Pages.Measures
{
    public class DeleteModel : PageModel
    {
        private readonly IMeasureService _measureService;

        public DeleteModel(IMeasureService measureService)
        {
            _measureService = measureService;
        }

        public IActionResult OnGet(int id)
        {
            _measureService.Delete(id);
            return Redirect("/Measures/RetrieveAll");
        }
    }
}
