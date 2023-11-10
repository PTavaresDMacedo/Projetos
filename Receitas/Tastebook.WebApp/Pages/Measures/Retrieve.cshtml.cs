using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.Measures;

namespace Tastebook.WebApp.Pages.Measures
{
    public class RetrieveModel : PageModel
    {
        private readonly IMeasureService _measureService;

        public RetrieveModel(IMeasureService measureService)
        {
            _measureService = measureService;
        }

        public Measure Measure { get; set; }

        public void OnGet(int id)
        {
            Measure = _measureService.Retrieve(id);
        }
    }
}
