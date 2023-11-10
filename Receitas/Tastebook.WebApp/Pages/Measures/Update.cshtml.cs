using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Receitas.Model;
using Receitas.Service.Measures;

namespace Tastebook.WebApp.Pages.Measures
{
    public class UpdateModel : PageModel
    {
        private readonly IMeasureService _measureService;

        public UpdateModel(IMeasureService measureService)
        {
            _measureService = measureService;
        }

        public Measure Measure { get; set; }

        public void OnGet(int id)
        {
            Measure = _measureService.Retrieve(id);
        }

        public IActionResult OnPost()
        {
            Measure measure = new Measure();
            measure.Id = Convert.ToInt32(Request.Form["id"]);
            measure.MeasureType = Convert.ToString(Request.Form["measure_type"]);
            _measureService.Update(measure);
            return Redirect("/Measures/RetrieveAll");
        }
    }
}
